using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    RaycastHit hit;
    Vector3 ray;
    //public Camera cam;
    Transform cam;
    public float range;

    Vector3 directionPos;
    Vector3 lookPos;
    Vector3 storeDir;

    float horizontal;
    float vertical;
    bool jumpInput;
    bool onGround;


    // Use this for initialization
    void Start()
    {
        //position = (Rect)((Screen.width - crosshairTexture.width) / 2, (Screen.hight - crosshairTexture.hight) / 2 crosshairTexture.width, crosshairTecture.hight);
        //cam = GetComponent<Camera>();

        cam = Camera.main.transform;
    }

    private void Update()
    {
        /*
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            print("I'm looking at " + hit.transform.name);
        else
            print("I'm looking at nothing!");*/
        if (Input.GetMouseButtonDown(0))
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            storeDir = cam.right;
            directionPos = transform.position + (storeDir * horizontal) + (cam.forward * vertical);

            Vector3 dir = directionPos - transform.position;

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position,cam.rotation);
            bullet.transform.Rotate(Vector3.forward * 90);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;

            Vector3 v = bullet.GetComponent<Rigidbody>().velocity.normalized;   //used for calulating the range

            float t = range / ((Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z)) / 3); //destroy bullet after some time

            Destroy(bullet, t);
        }
    }
}
