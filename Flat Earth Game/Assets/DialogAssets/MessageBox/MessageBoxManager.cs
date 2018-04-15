using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxManager : MonoBehaviour {

    public Text messageText;

    public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartOnScreenMessage(OnScreenMessage onScreenMessage)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in onScreenMessage.onScreenMessage)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndOnScreenMessage();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        messageText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            messageText.text += letter;
            yield return null;
        }
    }

    public void EndOnScreenMessage()
    {
        animator.SetBool("IsOpen", false);
    }
}
