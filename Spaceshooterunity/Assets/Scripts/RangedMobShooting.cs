//Taken from https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMobShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;

    public float bulletForce = 50f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f);
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
