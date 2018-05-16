using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
public class VideoPlayer : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;

        movie.loop = true;

        movie.Play();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
