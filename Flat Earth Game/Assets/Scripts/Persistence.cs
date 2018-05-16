using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour {

	private static bool created = false;

	[SerializeField]
	public Stat health;

	[SerializeField]
	public Stat persuate;

	void Awake()
	{
		if (!created)
		{
			health.Initialize();
			persuate.Initialize();
			DontDestroyOnLoad(this.gameObject);
			created = true;
			Debug.Log("Awake: " + this.gameObject);
		}
	}
}
