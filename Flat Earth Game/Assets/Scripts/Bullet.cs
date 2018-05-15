﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{


    AudioSource _audioSource;
    public AudioClip hitsound;

    // Use this for initialization
    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("hit");
        _audioSource.PlayOneShot(hitsound);

        GameObject hit = collision.gameObject;
        //print(""+hit.name);

		if (!hit.name.Equals ("Talf")) {
			Health health = hit.GetComponent<Health> ();
			if (health != null) {
				health.TakeDamage (25, hit);
			}
		}
		Destroy (gameObject, hitsound.length);
    }
}
