using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour {

	private static bool created = false;

	public int health;
	public int persuate;

	void Awake()
	{
		if (!created)
		{
			health = 100;
			persuate = 0;
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
	}
}
