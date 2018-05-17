using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicipalityManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 v = GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition; // Spawning Talf to right position
		GameObject.Find ("Talf").transform.position = v;
		GameObject.Find ("Persistence").GetComponent<Persistence> ().nextPosition = new Vector3 (130f, 0.88f,  -24.16f);
	}

}
