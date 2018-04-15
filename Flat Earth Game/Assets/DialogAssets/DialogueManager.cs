using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

    private Queue<string> names;
	private Queue<string> sentences;

    private bool isTriggered;

	// Use this for initialization
	void Start () {
        isTriggered = false;
        names = new Queue<string>();
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
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

    
    void FixedUpdate()
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
