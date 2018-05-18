using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingChecker : MonoBehaviour {

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public link_test door;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (target1 == null && target2 == null && target3 == null)
            {
				GameObject.Find ("Persistence").GetComponent<Persistence> ().trainingFinished = true;
                //display a message that player completed the training session and can pass
                GetComponent<OnScreenMessageTrigger>().displayMessage("Training Completed! Now you can exit the HeadQuarters!");
            }
			else
            {
				if (GameObject.Find ("Persistence").GetComponent<Persistence> ().trainingFinished == false) {					
					//display a message that player didn't complete the training session
					GetComponent<OnScreenMessageTrigger> ().displayMessage ("You cannot exit the HeadQuarters if you haven't finished the training.");
				} else {
					GetComponent<OnScreenMessageTrigger>().displayMessage("Training Completed! Now you can exit the HeadQuarters!");
				}
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<MessageBoxManager>().EndOnScreenMessage();
        }
    }
}
