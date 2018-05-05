using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat persuate;

	[SerializeField]
	private GameObject questPanel;

	private Animator questPanelAnimator;
	private bool isShown = false;

    private void Awake()
    {
        health.Initialize();
        persuate.Initialize();
    }

	void Start(){
		questPanelAnimator = questPanel.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {
            health.CurrentVal += 10;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            persuate.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            persuate.CurrentVal += 10;
        }
			
    }

	void LateUpdate(){
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if (isShown) {
				//HIDE QUEST PANEL
				questPanelAnimator.SetBool ("Show", false);
				isShown = false;
			} else {
				//SHOW QUEST PANEL
				questPanelAnimator.SetBool ("Show", true);
				isShown = true;
			}
		}
	}
}
