using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = 15f;
	private float startTime;
	private float journeyLength;
	private int m;

	// Use this for initialization
	void Start () {
		startMarker = GameObject.Find("StartMarker").GetComponent<Transform>();
		endMarker = GameObject.Find("EndMarker0").GetComponent<Transform>();
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		m = 0;
	}

	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		if (transform.position == endMarker.position) 
		{
			if (m == 3) {
				m = 0;
				startMarker = GameObject.Find ("StartMarker").GetComponent<Transform> ();
				endMarker = GameObject.Find ("EndMarker0").GetComponent<Transform> ();
				transform.Rotate (0, -90, 0);
			} else {
				startMarker = GameObject.Find("EndMarker"+m).GetComponent<Transform>();
				m++;
				endMarker = GameObject.Find("EndMarker"+m).GetComponent<Transform>();
			}

			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			if (m >1 ) {
				transform.Rotate (0, 45, 0);
			}

				
		}
	}
}
