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
                door.train_complete = true;
                //display a message that player completed the training session and can pass
                GetComponent<OnScreenMessageTrigger>().displayMessage("Training Completed! Now you can exit the HeadQuarters!");
            }
            else
            {
                door.train_complete = false;
                //display a message that player didn't complete the training session
                GetComponent<OnScreenMessageTrigger>().displayMessage("You cannot exit the HeadQuarters if you haven't finish the training.");
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
