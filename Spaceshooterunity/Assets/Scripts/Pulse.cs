using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pulse : MonoBehaviour
{
    public float pulseSpeed = 1.0f;
    public float pulseDmg = 5;
    public float pulseSize = 1f;
    public Transform player;


    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Mob mob = other.gameObject.GetComponent<Mob>();
        if (mob != null)
        {
            mob.TakeDamage(pulseDmg);
        }
    }

    public void pulseSpdUp()
    {
        pulseSpeed = pulseSpeed * 1.5f;
    }

    public void pulseDmgUp()
    {
        pulseDmg = (float)Math.Floor(pulseDmg * 1.75f);
    }

    public void pulseSizeUp()
    {
        transform.localScale = transform.localScale * 1.5f;
    }

}