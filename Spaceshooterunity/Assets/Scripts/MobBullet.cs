//Taken from https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys and https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys (mainly the second one)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int bulletDamage = 10;
    float startTime;

    /*void OnCollisionEnter2D(Collision2D collision){
        GameObject effect = Instantiate(hitEffect,transform.position, Quaternion.identity);
        Destroy(effect,0.1f);
        Destroy(gameObject);
    }*/
    void Start(){
        startTime = Time.time;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" || hitInfo.gameObject.tag == "Destructible")
        { 
            Debug.Log(hitInfo.name);
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(bulletDamage);
            }
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        deleteBullet();
    }

    //Made this so bullets don't just exist in the background
    void deleteBullet(){
        if(Time.time-startTime>3)
        {
            Destroy(gameObject);
        }
    }

}
