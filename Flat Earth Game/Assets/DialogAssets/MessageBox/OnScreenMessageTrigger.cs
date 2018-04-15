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

    private void OnTriggerStay(Collider col)
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
