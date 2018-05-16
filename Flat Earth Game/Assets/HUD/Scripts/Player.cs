using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField]
    private Stat health;

	[SerializeField]
    private Stat persuate;

    [SerializeField]
    private GameObject questPanel;

    private Animator questPanelAnimator;
    private bool isShown = false;


    AudioSource _audioSource;
    public AudioClip _audioClip;

    private void Awake()
    {
		health.Initialize();
		persuate.Initialize ();
    }

    void Start()
    {
        questPanelAnimator = questPanel.GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		health.CurrentVal = GameObject.Find ("Persistence").GetComponent<Persistence> ().health;
		persuate.CurrentVal = GameObject.Find ("Persistence").GetComponent<Persistence> ().persuate;
        if (Input.GetKeyDown(KeyCode.U))
        {
            health.CurrentVal += 10;
           // Game_Control.ctrl.health += 10;
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

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isShown)
            {
                //HIDE QUEST PANEL
                questPanelAnimator.SetBool("Show", false);
                isShown = false;
            }
            else
            {
                //SHOW QUEST PANEL
                questPanelAnimator.SetBool("Show", true);
                isShown = true;
            }
        }
    }
    public void TakeDamage(int amount, GameObject hit)
    {

		GameObject.Find ("Persistence").GetComponent<Persistence> ().health -= amount;
		health.CurrentVal -= amount;

		//print("health= " + health.CurrentVal);
        if (health.CurrentVal <= 0)
        {

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;
            _audioSource.PlayOneShot(_audioClip);

            Destroy(hit, _audioClip.length);
        }
    }
}
