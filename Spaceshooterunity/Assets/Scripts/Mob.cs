//Taken from https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
