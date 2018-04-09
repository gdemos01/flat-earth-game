using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public Camera main;
	public Camera photo;
	private bool useCamera;

	// Use this for initialization
	void Start () {
		photo.gameObject.SetActive (false);
		useCamera = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			main.gameObject.SetActive (!useCamera);
			photo.gameObject.SetActive (useCamera);
			useCamera = !useCamera;
		}	
	}
		
}