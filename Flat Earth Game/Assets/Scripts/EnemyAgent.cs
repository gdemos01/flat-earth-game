using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour {

	public GameObject character;
	AgentFSM states;

	private Vector3 destinationPoint;
	private NavMeshAgent agent;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {		
		agent = GetComponent<NavMeshAgent>();
		initialPosition = transform.position;
		character = GameObject.Find ("NASAAgent");
		states = character.GetComponent<AgentFSM> ();
	}
	
	// Update is called once per frame
	void Update () {
		states.Walk();
		destinationPoint = GameObject.Find ("Talf").GetComponent<Transform> ().position;
		agent.SetDestination (destinationPoint);
	}
}
