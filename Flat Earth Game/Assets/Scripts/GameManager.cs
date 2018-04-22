using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public Camera main;
	public Camera photo;
	public GameObject cameraFrame;
	public QuestManager questManager;
	public GameObject Q1Point;
	public GameObject q3Leader;
	public GameObject Talf;
	private bool useCamera;
	public AudioSource shutter;
	public AudioSource signature;

	// Use this for initialization
	void Start () {
		photo.gameObject.SetActive (false);
		cameraFrame = GameObject.Find ("CameraFrame");
		Q1Point = GameObject.Find ("Q1Point");
		q3Leader = GameObject.Find ("Leader");
		Talf = GameObject.Find ("Talf");
		questManager = GameObject.Find ("QuestManager").GetComponent<QuestManager>();
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
			FindObjectOfType<MessageBoxManager>().EndOnScreenMessage(); 			// Hides any on screen messages
		}	

		if (Input.GetKeyDown (KeyCode.E) && useCamera) {
			// Set trigger to Finish Q1 or Q2 here
			if (Vector3.Distance (Talf.transform.position, Q1Point.transform.position) < 2) {
				questManager.changeObjectiveStatus ("Q1", true);
				FindObjectOfType<MessageBoxManager>().EndOnScreenMessage(); 				// Hides any on screen messages
				Q1Point.GetComponent<OnScreenMessageTrigger>().displayMessage("Congratulations! You completed the strainght lake objective");
				print ("Congratulations! You completed the strainght lake objective");
				print (questManager.getPercentageFinished ());
			}
			shutter.Play();
		}

		// Check for Q3
		DialogueManager dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
		if (dm.dialogueBegan && dm.dialogueFinishedEntierly){
			questManager.changeObjectiveStatus ("Q3", true);
			signature.Play ();
			print ("Congratulations! You completed the Q3 objective");
			FindObjectOfType<MessageBoxManager>().EndOnScreenMessage(); 			// Hides any on screen messages
			q3Leader.GetComponent<OnScreenMessageTrigger>().displayMessage("Congratulations! You completed the Q3 objective");
			dm.dialogueBegan = false;
		}
	}
		
}