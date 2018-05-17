using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour {

	private static bool created = false;

	public int health;
	public int persuate;
	public Transform playerPosition;
	public Vector3 nextPosition;
	public bool trainingFinished;

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
		}
	}
}
