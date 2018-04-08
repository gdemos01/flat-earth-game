using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    Animator animator;
    bool doorOpen;

	// Use this for initialization
	void Start () {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorAction("Open");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorAction("Close");
        }
    }

    void DoorAction(string direction)
    {
        animator.SetTrigger(direction);
    }

    // Update is called once per frame
    void Update () {

    }
}
