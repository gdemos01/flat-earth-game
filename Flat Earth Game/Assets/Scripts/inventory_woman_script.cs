using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_woman_script : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth;

    AudioSource _audioSource;
    public AudioClip _audioClip;

    // Use this for initialization
    void Start () {

        _audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void TakeDamage(int amount, GameObject hit)
    {
        //_audioSource.PlayOneShot(hitsound);

        currentHealth -= amount;
        // print("health= " + currentHealth);
        if (currentHealth <= 0)
        {

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;
            _audioSource.PlayOneShot(_audioClip);

            Destroy(hit, _audioClip.length);
        }
    }
}
