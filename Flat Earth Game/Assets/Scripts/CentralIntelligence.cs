using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CentralIntelligence : MonoBehaviour {

	public GameObject agentPrefab;
	public GameObject[] agents;
	public GameObject[] citizens;
	public GameObject[] citizenDP;
	public GameObject[] parkCitizens;
	public GameObject[] parkDP;
	public GameObject[] cars;
	public AgentFSM states;
	private Vector3 destinationPoint;
	private NavMeshAgent meshAgent;
	private int timeInGame;
	private int carsLeft;
	private Transform startMarker;
    public QuestManager questManager;


	// Use this for initialization
	void Start () {
		carsLeft = 0;
		startMarker = GameObject.Find ("StartMarker").GetComponent<Transform> ();
		// Set Destination points for citizens
		citizenDP = GameObject.FindGameObjectsWithTag ("DestinationPoint");
		parkDP = GameObject.FindGameObjectsWithTag ("ParkDP");
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
	}

	// Spanws a new agent at x,y,z
	void spawnAgent(float x, float y, float z)
	{
		Instantiate (agentPrefab, new Vector3 (x,y,z),Quaternion.identity);
	}
		
	// Update is called once per frame
	void Update () {


		timeInGame = GameObject.Find ("Persistence").GetComponent<Persistence> ().timeInGame;
		print (timeInGame);

		// Citizens 
		if (timeInGame % 200 == 0) {
			citizens = GameObject.FindGameObjectsWithTag ("Citizen");
			foreach (GameObject citizen in citizens)
			{
				// Randomly select next destination for citizen
				int r = Random.Range (0, citizenDP.Length);
				//print (r);
				destinationPoint = citizenDP[r].GetComponent<Transform> ().position;
				citizen.GetComponent<NavMeshAgent> ().SetDestination (destinationPoint);
			}

			//park
			parkCitizens = GameObject.FindGameObjectsWithTag ("ParkCitizen");
			foreach (GameObject parkCitizen in parkCitizens)
			{
				// Randomly select next destination for citizen
				int r = Random.Range (0, parkDP.Length);
				//print (r);
				destinationPoint = parkDP[r].GetComponent<Transform> ().position;
				parkCitizen.GetComponent<NavMeshAgent> ().SetDestination (destinationPoint);
			}
		}

		// CARS
		if (timeInGame % 220 == 0 && carsLeft < 3){
			Instantiate (cars [carsLeft], startMarker.position, cars[carsLeft].transform.rotation);
			carsLeft++;
		}

		// RULE BASED A.I.

		// Normal Time Spawn
		if ((timeInGame % 5000 == 0) && timeInGame < 20000) 
		{
			spawnAgent (-98,(float)0.8333,44);
		}

		// Aggresive Time Spawn
		if ((timeInGame % 2500 == 0) && timeInGame > 20000) 
		{
			spawnAgent (-98,(float)0.8333,44);
		}

		// Mild Quest Spawn
		if (questManager.getPercentageFinished () < 34 && (timeInGame % 6000 == 0)) 
		{
			spawnAgent (-98, (float)0.8333, 44);
		}

		// Moderate Quest Spawn
		if (questManager.getPercentageFinished () >= 34 && questManager.getPercentageFinished () <= 67 && (timeInGame % 6000 == 0)) 
		{
			spawnAgent (-97, (float)0.8333, 43);
			spawnAgent (-98, (float)0.8333, 44);
		}

		// Aggresive Quest Spawn
		if (questManager.getPercentageFinished () > 67 && (timeInGame % 6000 == 0)) 
		{
			spawnAgent (-96, (float)0.8333, 42);
			spawnAgent (-97, (float)0.8333, 43);
			spawnAgent (-98, (float)0.8333, 44);
		}
			
		// Command Agents
		agents = GameObject.FindGameObjectsWithTag ("EnemyAgent");
		foreach (GameObject agent in agents)
		{
			states = agent.GetComponent<AgentFSM> ();
			meshAgent = agent.GetComponent<NavMeshAgent>();
			destinationPoint = GameObject.Find ("Talf").GetComponent<Transform> ().position -  new Vector3(2f,0f,0f);
			states.evaluateState (destinationPoint);
			meshAgent.SetDestination (destinationPoint);
		}
	}
}
