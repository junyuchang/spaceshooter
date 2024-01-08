//Taken from https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float health = 50f;
    public int damage = 100;
    public bool bombMob = false;
    public bool onFire = false;
    private float nextBurnTick = 5.0f;
    private float burnDamage=0f;
    public SpriteRenderer sp;

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

    public void SetOnFire()
    {
        onFire = true;
        nextBurnTick = Time.time;
        sp.color = Color.red;
    }

    public void SetFireDamage(float damage)
    {
        burnDamage = damage;
    }

    void OnCollisionEnter2D(Collision2D hitInfo){
        //Debug.Log("somethign");
        Debug.Log(hitInfo.gameObject);
        Player player = hitInfo.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            if(bombMob)
            {
                Die();
            }
        }
    }

    void Update(){
        if(onFire==true)
        {
            Debug.Log("fire tick should happen now");
            if(Time.time > nextBurnTick)
            {
                nextBurnTick+=5.0f;
                TakeDamage(burnDamage);
            }

        }
    }
}
