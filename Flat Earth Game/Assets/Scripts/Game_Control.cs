using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Control : MonoBehaviour {

    public static Game_Control ctrl;

    public int health;
    public int persuation;


	// Use this for initialization
	void Awake () {
        if (ctrl == null)
        {
            DontDestroyOnLoad(gameObject);
            ctrl = this;
        }
        else if (ctrl != this) {
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
