using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public bool dialogueBegan;
	public bool dialogueFinishedEntierly;
	public Animator animator;

    private Queue<string> names;
	private Queue<string> sentences;

    private bool isTriggered;

	// Use this for initialization
	void Start () {
        isTriggered = false;
        names = new Queue<string>();
		sentences = new Queue<string>();
		dialogueBegan = false;
		dialogueFinishedEntierly = false;

	}

	public void StartDialogue (Dialogue dialogue)
	{
		// Notify everyone that a dialogue has began
		dialogueBegan = true;
		dialogueFinishedEntierly = false;

        //Call the dialogue box on screen
        animator.SetBool("IsOpen", true);

        //Initialize names into a queue
        names.Clear();

        foreach(string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        //Initialize sentences into a queue
		sentences.Clear();

        foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
    }

	public void DisplayNextSentence ()
	{
        //if there are no more sentences
		if (sentences.Count == 0)
		{
			// Notify everyone that the dialog has finished entierly
			dialogueFinishedEntierly = true;
			EndDialogue();
			return;
		}
        

        //Change Actor Name
        nameText.text = names.Dequeue();

        //Change Talk
        string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

    /**
     * Talk animation
     */
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

    /* End conversation dialogue
     */
	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
        isTriggered = false;
    }

    
    void Update()
    {
        /**
        * Press R instead of continue>> button on screen
        * fordisplaying the next sentence
        */
        if (Input.GetKeyDown(KeyCode.R) && isTriggered)
        {
            DisplayNextSentence();
        }
    }

    public void setTriggered(bool value)
    {
        isTriggered = value;
    }

    public bool IsTriggered()
    {
        return isTriggered;
    }

}
