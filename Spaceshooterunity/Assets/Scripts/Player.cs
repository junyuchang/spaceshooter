using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    public int health;
    public GameObject deathMenu;
    public HealthBar healthbar;
    public Tilemap tiles;

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

        if(tiles.GetTile(Vector3Int.FloorToInt(transform.position)).name == "Starry background 2 red")
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
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
}
