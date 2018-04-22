using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = 0.5f;
	private float startTime;
	private float journeyLength;
	private bool finishedGame;
	private bool initialized;
	public AudioSource halo;

	// Use this for initialization
	void Start () {
		initialized = false;
		finishedGame = false;
	}

	// Update is called once per frame
	void Update () {
		if (finishedGame) {
			if (!initialized) {
				halo.Play ();
				startMarker = GameObject.Find ("earth").GetComponent<Transform> ();
				endMarker = GameObject.Find ("space").GetComponent<Transform> ();
				startTime = Time.time;
				journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
				transform.Rotate (90, 0, 0);
				initialized = true;
			}
			speed = speed + speed * 0.001f;
			print (speed);
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
		} else {
			if (Input.GetKeyDown (KeyCode.F)) {
				finishedGame = true;
			}
		}
	}
}
