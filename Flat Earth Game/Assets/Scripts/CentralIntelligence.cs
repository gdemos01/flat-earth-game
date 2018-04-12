﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CentralIntelligence : MonoBehaviour {

	public GameObject agentPrefab;
	public GameObject[] agents;
	public GameObject[] cars;
	public QuestManager questManager;
	public AgentFSM states;
	private Vector3 destinationPoint;
	private NavMeshAgent meshAgent;
	private int timeInGame;
	private int carsLeft;
	private Transform startMarker;


	// Use this for initialization
	void Start () {
		questManager = GameObject.Find ("QuestManager").GetComponent<QuestManager> ();
		// The creation of the quest here is temporary
		List<string> objectives = new List<string> ();
		objectives.Add ("Q1");
		objectives.Add ("Q2");
		objectives.Add ("Q3");
		questManager.createNewQuest ("Quest", objectives);
		timeInGame = 1;
		carsLeft = 0;
		startMarker = GameObject.Find ("StartMarker").GetComponent<Transform> ();
	}

	// Spanws a new agent at x,y,z
	void spawnAgent(float x, float y, float z)
	{
		Instantiate (agentPrefab, new Vector3 (x,y,z),Quaternion.identity);
	}
		
	// Update is called once per frame
	void Update () {

		// CARS
		if (timeInGame % 140 == 0 && carsLeft < 4){
			Instantiate (cars [carsLeft], startMarker.position, cars[carsLeft].transform.rotation);
			carsLeft++;
		}

		// RULE BASED A.I.
		timeInGame++;
		//print (timeInGame);

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
		if (questManager.getPercentageFinished () >= 34 && questManager.getPercentageFinished () < 66 && (timeInGame % 6000 == 0)) 
		{
			spawnAgent (-97, (float)0.8333, 43);
			spawnAgent (-98, (float)0.8333, 44);
		}

		// Aggresive Quest Spawn
		if (questManager.getPercentageFinished () >= 67 && (timeInGame % 6000 == 0)) 
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
			destinationPoint = GameObject.Find ("Talf").GetComponent<Transform> ().position -  new Vector3(3f,0f,0f);
			states.evaluateState (destinationPoint);
			meshAgent.SetDestination (destinationPoint);
		}
	}
}
