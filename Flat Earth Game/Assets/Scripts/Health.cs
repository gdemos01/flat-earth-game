using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth;

    AudioSource _audioSource;
    public AudioClip _audioClip;
  //  public AudioClip hitsound;
    

    private void Start()
    {

      _audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount, GameObject hit)
    {
        //_audioSource.PlayOneShot(hitsound);

        currentHealth -= amount;
       // print("health= " + currentHealth);
        if (currentHealth<=0) {

           Renderer[] renderers = GetComponentsInChildren<Renderer>();
           foreach (Renderer r in renderers)
           r.enabled = false;
           _audioSource.PlayOneShot(_audioClip);

            Destroy(hit, _audioClip.length);
        }
    }
}
