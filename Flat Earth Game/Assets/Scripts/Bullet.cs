using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
      //  print("hit");

        GameObject hit = collision.gameObject;
        print(""+hit.name);
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(25, hit);
        }

        Destroy(gameObject);
    }
}
