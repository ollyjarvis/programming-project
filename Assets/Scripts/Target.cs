using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 150f;

    public ScoreScr scoreScript;

    public void TakeDamage (float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0f)
        {
            scoreScript.score += 1;
            scoreScript.newScore();
            Die();
            FindObjectOfType<Gun>().spawnTarget();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
