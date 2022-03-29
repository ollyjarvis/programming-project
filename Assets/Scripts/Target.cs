using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 150f;

    public void TakeDamage (float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0f)
        { 
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}