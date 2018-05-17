using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorDialogueSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.Find("Persistence").GetComponent<Persistence>().finishedQuests)
        {
            GetComponent<DialogueObjectTrigger>().dialogue = new Dialogue();

            GetComponent<DialogueObjectTrigger>().dialogue.name = new string[7];

            //insert names
            GetComponent<DialogueObjectTrigger>().dialogue.name[0] = "Talf";
            GetComponent<DialogueObjectTrigger>().dialogue.name[1] = "Mrs. Mayor";
            GetComponent<DialogueObjectTrigger>().dialogue.name[2] = "Mrs. Mayor";
            GetComponent<DialogueObjectTrigger>().dialogue.name[3] = "Mrs. Mayor";
            GetComponent<DialogueObjectTrigger>().dialogue.name[4] = "Mrs. Mayor";
            GetComponent<DialogueObjectTrigger>().dialogue.name[5] = "Mrs. Mayor";
            GetComponent<DialogueObjectTrigger>().dialogue.name[6] = "Talf";

            GetComponent<DialogueObjectTrigger>().dialogue.sentences = new string[7];

            //insert sentences
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[0] = "Mrs. Mayor, Mrs. Mayor..! I have the evidence!";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[1] = "Really..? Let me see..";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[2] = "...";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[3] = "....";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[4] = "...I can't believe it! According to these evidence, the earth is indeed FLAT!!!";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[5] = "Talf, our community will support your quest to enlighten the world!";
            GetComponent<DialogueObjectTrigger>().dialogue.sentences[6] = "Thank you Mrs. Mayor.. let's do this! GO FLAT EARTHERS!";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
