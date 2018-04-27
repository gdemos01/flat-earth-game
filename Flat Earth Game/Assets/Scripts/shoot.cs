using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start () {
    }

    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;

        // NetworkServer.Spawn(bullet);
         Destroy(bullet, 2.0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Pressed primary button.");
            CmdFire();
        }
    }
}
