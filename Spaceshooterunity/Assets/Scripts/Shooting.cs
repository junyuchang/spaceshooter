//Taken from https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;

    public float bulletForce = 50f;
    public float firerate = 3f;
    private bool isShooting = false;
    private Coroutine shooting;
    private bool toggleOn = false;
    private float waitTime;
    // Update is called once per frame
    void Update()
    {
        if (!toggleOn && Input.GetKeyDown(KeyCode.Space))
        {
            shooting = StartCoroutine(ShootCoroutine());
            toggleOn = true;
            isShooting = true;
        }
        else if (toggleOn && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(shooting);
            toggleOn = false;
            isShooting = false;
        }
        else if (!toggleOn)
        {
            if (Input.GetButtonDown("Fire1") && !isShooting)
            {
                shooting = StartCoroutine(ShootCoroutine());
                isShooting = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                StopCoroutine(shooting);
                isShooting = false;
            }
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / firerate);
            shoot();
        }
    }

    void shoot(){
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void FireRateUp()
    {
        firerate = firerate * 1.75f;
    }
}
