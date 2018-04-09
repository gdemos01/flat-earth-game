using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public Camera main;
	public Camera photo;
	public GameObject cameraFrame;
	private bool useCamera;
	public AudioSource shutter;

	// Use this for initialization
	void Start () {
		photo.gameObject.SetActive (false);
		cameraFrame = GameObject.Find ("CameraFrame");
		useCamera = false;
		cameraFrame.SetActive (useCamera);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			useCamera = !useCamera;
			photo.gameObject.SetActive (useCamera);
			main.gameObject.SetActive (!useCamera);
			cameraFrame.SetActive (useCamera);
		}	

		if (Input.GetKeyDown (KeyCode.E) && useCamera) {
			// Set trigger to Finish Q1 or Q3 here
			shutter.Play();
		}
	}
		
}