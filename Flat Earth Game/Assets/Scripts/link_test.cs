using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class link_test : MonoBehaviour {
    Scene sc;
    public int door;// 1 goes to hq , 2 goes to Municipality

   public bool training_completed = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
		StartCoroutine (changeScene (other));
    }

	IEnumerator changeScene(Collider other){
		sc = SceneManager.GetActiveScene();
		if (other.gameObject.tag == "Player") {
			if ((sc.name == "hq") || (sc.name == "Municipality")) {
				float fadeTime = GameObject.Find ("MayorManager").GetComponent<Fading> ().BeginFade (1);
				yield return new WaitForSeconds (fadeTime);
				SceneManager.LoadScene (2);
			} else {
				if (door == 1)
				{
					SceneManager.LoadScene(0);
				}

				if (door==2) {
					SceneManager.LoadScene(2);
				}
			}
		}
	}
}
