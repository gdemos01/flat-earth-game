using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenMessageTrigger : MonoBehaviour {

    public OnScreenMessage onScreenMessage;

    /*AUTOMATIC ACTION
     * 
    private void OnTriggerEnter(Collider col)
    {
         
    }*/

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<MessageBoxManager>().StartOnScreenMessage(onScreenMessage);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<MessageBoxManager>().EndOnScreenMessage();
        }
    }

	public void displayMessage(string msg){
		onScreenMessage.setOnScreenMessage (msg);
		FindObjectOfType<MessageBoxManager> ().StartOnScreenMessage (onScreenMessage);
	}


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
