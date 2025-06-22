using NUnit;
using System;
using UnityEngine;

public class DestroyableObj : MonoBehaviour
{
    public float enemyHealth;
    public GameObject deadEffect;



    public void takeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}


