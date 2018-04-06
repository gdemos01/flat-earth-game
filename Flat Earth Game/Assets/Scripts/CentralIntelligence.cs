using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CentralIntelligence : MonoBehaviour {

	public GameObject agentPrefab;
	public GameObject[] agents;

	AgentFSM states;
	private Vector3 destinationPoint;
	private NavMeshAgent meshAgent;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (agents.Length < 250) 
		{
			Instantiate (agentPrefab, new Vector3 ((float)128.6, (float)0.83333,(float) 35.61394),Quaternion.identity);
			agents = GameObject.FindGameObjectsWithTag ("EnemyAgent");
		}

		foreach (GameObject agent in agents)
		{
			states = agent.GetComponent<AgentFSM> ();
			meshAgent = agent.GetComponent<NavMeshAgent>();
			states.Walk();
			destinationPoint = GameObject.Find ("Talf").GetComponent<Transform> ().position;
			meshAgent.SetDestination (destinationPoint);
		}
	}
}
