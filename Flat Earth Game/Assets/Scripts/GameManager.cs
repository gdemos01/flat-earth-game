using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public Camera main;
	public Camera photo;
	public GameObject cameraFrame;
	public QuestManager questManager;
	public GameObject Q1Point;
	public GameObject Talf;
	private bool useCamera;
	public AudioSource shutter;
	public AudioSource signature;
	bool approachedQuest;

	// Use this for initialization
	void Start () {
		photo.gameObject.SetActive (false);
		cameraFrame = GameObject.Find ("CameraFrame");
		Q1Point = GameObject.Find ("Q1Point");
		Talf = GameObject.Find ("Talf");
		questManager = GameObject.Find ("QuestManager").GetComponent<QuestManager>();
		useCamera = false;
		cameraFrame.SetActive (useCamera);
		approachedQuest = true;
	}

	// Update is called once per frame
	void Update () {
		float distanceFromQ1 = Vector3.Distance (Talf.transform.position, Q1Point.transform.position);

		if (approachedQuest &&  distanceFromQ1< 2) {
			print ("Looks like a nice place to take a photo of the lake");
			approachedQuest = false;
		} 

		if (distanceFromQ1 >= 2) {
			approachedQuest = true;
		};

		if (Input.GetKeyDown (KeyCode.C)) {
			useCamera = !useCamera;
			photo.gameObject.SetActive (useCamera);
			main.gameObject.SetActive (!useCamera);
			cameraFrame.SetActive (useCamera);

		}	

		if (Input.GetKeyDown (KeyCode.E) && useCamera) {
			// Set trigger to Finish Q1 or Q2 here
			if (Vector3.Distance (Talf.transform.position, Q1Point.transform.position) < 2) {
				questManager.changeObjectiveStatus ("Q1", true);
				print ("Congratulations! You completed the first objective");
				print (questManager.getPercentageFinished ());
			}
			shutter.Play();
		}

		// Check for Q3
		DialogueManager dm = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
		GameObject q3Leader = GameObject.Find ("Leader");
		if (dm.dialogueBegan && dm.dialogueFinishedEntierly){
			questManager.changeObjectiveStatus ("Q3", true);
			signature.Play ();
			print ("Congratulations! You completed the Q3 objective");
			// Hides any on screen messages
			FindObjectOfType<MessageBoxManager>().EndOnScreenMessage();
			q3Leader.GetComponent<OnScreenMessageTrigger>().displayMessage("Congratulations! You completed the Q3 objective");
			dm.dialogueBegan = false;
		}
	}
		
}