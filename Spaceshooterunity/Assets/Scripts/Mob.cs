//Taken from https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float health = 50f;
    public int damage = 100;

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

    void OnCollisionEnter2D(Collision2D hitInfo){
        //Debug.Log("somethign");
        Debug.Log(hitInfo.gameObject);
        Player player = hitInfo.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        /*Mob enemy = hitInfo.GetComponent<Mob>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }*/
    }
}
