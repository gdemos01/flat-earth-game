using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFSM : MonoBehaviour
{

    const int countOfDamageAnimations = 3;
    int lastDamageAnimation = -1;
    private Animator animator;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    int shooti = 0;

    public void evaluateState(Vector3 target)
    {
        float distance = Vector3.Distance(target, transform.position);
        if (distance > 50)
        {
            Walk();
        }
        else if (distance > 1 && distance <= 50)
        {
            Run();
            //print (distance);
        }
        else
        {
            // Panaxas comes here
            // Add connections to your fighting scene here
            // Feel free to use any other animations instead of attack() 
            // Look at the entire script
            // NOTE: ENEMIES SHOULD DIE EASYLY (MAYBE JUST A COUPLE OF TURTLE SHOTS				
            transform.rotation = Quaternion.LookRotation(target);
            Attack();

            shooti++;
            if (shooti - 100 >= System.Int32.MaxValue) { shooti = 0; }
            if ((shooti % 20) == 0)
            {
                // Shooting

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.LookRotation(target));
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;
                Vector3 v = bullet.GetComponent<Rigidbody>().velocity.normalized;   //used for calulating the range

                float t = 1 / ((Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z)) / 3); //destroy bullet after some time

                Destroy(bullet, t);
            }
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Stay()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0f);
    }

    public void Walk()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0.5f);
    }

    public void Run()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 4f);
    }

    public void Attack()
    {
        Aiming();
        animator.SetTrigger("Attack");
    }

    public void Death()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            animator.Play("Idle", 0);
        else
            animator.SetTrigger("Death");
    }

    public void Damage()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
        int id = Random.Range(0, countOfDamageAnimations);
        if (countOfDamageAnimations > 1)
            while (id == lastDamageAnimation)
                id = Random.Range(0, countOfDamageAnimations);
        lastDamageAnimation = id;
        animator.SetInteger("DamageID", id);
        animator.SetTrigger("Damage");
    }

    public void Jump()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", false);
        animator.SetTrigger("Jump");
    }

    public void Aiming()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", true);
    }

}
