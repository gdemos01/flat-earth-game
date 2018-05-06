using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
    currentHealth = maxHealth;
    }

    public void TakeDamage(int amount, GameObject hit)
    {
        currentHealth -= amount;
        print("health= " + currentHealth);
        if (currentHealth<=0) {
            Destroy(hit);
        }
    }
}
