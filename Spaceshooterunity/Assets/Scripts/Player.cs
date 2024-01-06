using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    public int health;
    public float armor = 1.0f;

    public GameObject deathMenu;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);   
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        */

        if (health <= 0)
        {
            Time.timeScale = 0f;
            die();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= Convert.ToInt32(damage *armor);
        healthbar.SetHealth(health);
    }

    void die()
    {
        deathMenu.SetActive(true);
    }

    public void Revive()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    //This increases health by 1.2 for now can think of a scalling idea later.
    //Also full restores health
    public void HealthUpgrade()
    {
        maxHealth = Convert.ToInt32(maxHealth *1.2);
        health = maxHealth;
    }
    //Armor will just be a value that reduces the value of damage taken each time
    //the player gets hit so armor will range from 1-0.1 and will multiply damage taken by the
    //player so each enemy hit does less.
    public void upgradeArmor()
    {
        armor = armor *0.8f;
    }
}
