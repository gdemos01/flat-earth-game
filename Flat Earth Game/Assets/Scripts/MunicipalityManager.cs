using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MunicipalityManager : MonoBehaviour {

    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
		Vector3 v = GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition; // Spawning Talf to right position
		GameObject.Find ("Talf").transform.position = v;
		GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition = new Vector3 (130f, 0.88f,  -24.16f);

        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if(dialogueManager.dialogueBegan && dialogueManager.dialogueFinishedEntierly)
        {
            if (GameObject.Find("Persistence").GetComponent<Persistence>().finishedQuests)
            {
                GameObject.Find("Persistence").GetComponent<Persistence>().gameFinished = true;
                StartCoroutine(LoadScene());
            }
            else if(!GameObject.Find("Persistence").GetComponent<Persistence>().initializeQuests)
            {
                // initialize quests
                GameObject.Find("Persistence").GetComponent<Persistence>().initializeQuests = true;
                GameObject.Find("Persistence").GetComponent<Persistence>().receiveQuests = true;
                GameObject.Find("Talf").GetComponent<Player>().questInitAudio.Play();
            }
        }
    }

    IEnumerator LoadScene()
    {
        float fadeTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(3);
    }
}
