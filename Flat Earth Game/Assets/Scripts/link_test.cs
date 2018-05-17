﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class link_test : MonoBehaviour {
    Scene sc;
    public int door;// 1 goes to hq , 2 goes to Municipality
    public bool train_complete = false;

    // Use this for initialization
    void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
		train_complete = GameObject.Find ("Persistence").GetComponent<Persistence> ().trainingFinished;
	}
    void OnTriggerEnter(Collider other)
    {
		StartCoroutine (changeScene (other));
    }

	IEnumerator changeScene(Collider other){
		sc = SceneManager.GetActiveScene();
		if (other.gameObject.tag == "Player") {
            if(sc.name == "hq"){
                if (train_complete == true) {
                    float fadeTime = GetComponent<Fading>().BeginFade(1);
                    yield return new WaitForSeconds(fadeTime);
                    SceneManager.LoadScene(3);
                }
            } 
            
            else if(sc.name == "Municipality") {
               
				float fadeTime = GetComponent<Fading> ().BeginFade (1);
				yield return new WaitForSeconds (fadeTime);
				SceneManager.LoadScene (3);
			} else {
				if (door == 1)
				{
					GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition = new Vector3 (16.56f, 0.02f,  -12.9f);
                    float fadeTime = GetComponent<Fading>().BeginFade(1);
                    yield return new WaitForSeconds(fadeTime);
                    SceneManager.LoadScene(2);
				}

				if (door==2) {
					GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition = new Vector3 (-0.03f, 0f,  15.75f);
                    float fadeTime = GetComponent<Fading>().BeginFade(1);
                    yield return new WaitForSeconds(fadeTime);
                    SceneManager.LoadScene(4);
				}
			}
		}
	}
}
