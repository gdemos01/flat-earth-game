using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutscene : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;
	public float speed = 0.5f;
	private float startTime;
	private float journeyLength;
	private bool finishedGame;
	private bool initialized;
	public AudioSource halo;

    private bool cutSceneFinished;

	// Use this for initialization
	void Start () {
		initialized = false;
		finishedGame = GameObject.Find("Persistence").GetComponent<Persistence>().gameFinished;
        cutSceneFinished = false;
    }

	// Update is called once per frame
	void Update () {

		//print ("game "+finishedGame +" cut "+cutSceneFinished);
		if (finishedGame && !cutSceneFinished) {

            //stop basic music
            GameObject.Find("Talf").GetComponent<AudioSource>().Stop();

			if (!initialized) {
				halo.Play ();

				startMarker = GameObject.Find ("earth").GetComponent<Transform> ();
				endMarker = GameObject.Find ("space").GetComponent<Transform> ();
				startTime = Time.time;
				journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
				transform.Rotate (90, 0, 0);
				initialized = true;
			}

            speed = speed + speed * 0.001f;

            float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
            
            if(transform.position == endMarker.position)
            {
                StartCoroutine(FadeOut(halo, 0.9f));
                cutSceneFinished = true;
            }
		}
	}

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
		GameObject.Find ("Persistence").GetComponent<Persistence> ().RespawnPlayer ();
        SceneManager.LoadScene(0);
    }
}
