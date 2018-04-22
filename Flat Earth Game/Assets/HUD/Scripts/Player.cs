using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat persuate;

    private void Awake()
    {
        health.Initialize();
        persuate.Initialize();
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
}
