using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour {

	private static bool created = false;

	public int health;
	public int persuate;
	public Transform playerPosition;
	public Vector3 nextPosition;
	public int timeInGame;
	public bool trainingFinished;

    public bool q1, q2, q3, receiveQuests;
    public bool finishedQuests;

    public bool gameFinished;

    public bool initializeQuests;

	void Awake()
	{
		if (!created)
		{
			trainingFinished = false;
			playerPosition = GameObject.Find ("Talf").transform;
			health = 100;
			persuate = 0;
			nextPosition = playerPosition.position;
			DontDestroyOnLoad(this.gameObject);
			created = true;
            finishedQuests = false;
            gameFinished = false;
            initializeQuests = false;
            q1 = false;
            q2 = false;
            q3 = false;
			timeInGame = 1;
            receiveQuests = false;
		}
	}

	void Update(){
		// Finished All Quests
		if (q1 && q2 && q3) {
			finishedQuests = true;
		} 
		// Time in Game in Frames
		timeInGame+=1;
	}

    public void RespawnPlayer()
    {
        trainingFinished = false;
        playerPosition = GameObject.Find("Talf").transform;
        health = 100;
        persuate = 0;
        nextPosition = new Vector3(26.03f, 6.9f, 9.29f);
        DontDestroyOnLoad(this.gameObject);
        created = true;
        finishedQuests = false;
        gameFinished = false;
        initializeQuests = false;
        q1 = false;
        q2 = false;
        q3 = false;
        receiveQuests = false;
		timeInGame = 0;
    }
}
