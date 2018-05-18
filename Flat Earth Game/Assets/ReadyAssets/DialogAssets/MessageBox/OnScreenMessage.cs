using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnScreenMessage {

    [TextArea(3, 10)]
    public string[] onScreenMessage;

    public void setOnScreenMessage(string sentence)
    {
        onScreenMessage[0] = sentence;
    }

    public void setOnScreenMessages(string[] sentences)
    {
        onScreenMessage = sentences;
    }

}
