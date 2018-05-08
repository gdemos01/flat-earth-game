using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class link_test : MonoBehaviour {
    Scene sc;
    public int door;// 1 goes to hq , 2 goes to Municipality


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        sc = SceneManager.GetActiveScene();
        //   print("contact");
         if (other.gameObject.tag == "Player")
        {
            if ((sc.name == "hq") || (sc.name == "Municipality"))
                SceneManager.LoadScene(1);
            if (sc.name == "Sandbox") { 
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
