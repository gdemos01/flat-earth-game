using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    Animator animator;
    bool doorOpen;

    // Use this for initialization
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorOpen = true;
            animator.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            animator.SetBool("open", false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
