using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Dialogue Class that acts as a Unity Component
 */ 
[System.Serializable]
public class Dialogue {

    [TextArea(3, 10)]
    public string[] name;

	[TextArea(3, 10)]
	public string[] sentences;

}
