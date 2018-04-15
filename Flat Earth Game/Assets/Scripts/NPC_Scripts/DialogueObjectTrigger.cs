using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * DialogueObjectTrigger Class need to be assinged on an object with a defined box collider
 */
public class DialogueObjectTrigger : MonoBehaviour {

    public Dialogue dialogue;

    /*AUTOMATIC ACTION
     * 
    private void OnTriggerEnter(Collider col)
    {
         if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }*/

private void OnTriggerStay(Collider col)
    {
		if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.E) && FindObjectOfType<DialogueManager>().IsTriggered()==false)
        {
            FindObjectOfType<DialogueManager>().setTriggered(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().setTriggered(false);
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
