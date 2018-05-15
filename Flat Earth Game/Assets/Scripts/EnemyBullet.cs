using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

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
		Player health = hit.GetComponent<Player>();
		if (health != null)
		{
			health.TakeDamage(25, hit);
		}

		Destroy(gameObject, hitsound.length);
	}
}
