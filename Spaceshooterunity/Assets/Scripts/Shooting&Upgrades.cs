//Taken from https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public GameObject fireBulletPreFab;
    public GameObject pulseSprite;

    public float bulletForce = 50f;
    public float firerate = 4f;

    private bool isShooting = false;
    private Coroutine shooting;
    private bool toggleOn = false;
    public float pulsespdLvl = 1f;
    //upgrades (maybe move to different script like stats or something in future)
    public int fireRateLvl = 1, coneLvl = 1, lineLvl = 1, bulletspdLvl = 1, pulseLvl = 0, fireDamageLvl=0;
    private Coroutine pulsing;
    private bool pulsestarted = false;

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

        // apply pulse dmg
        if (pulsestarted == false && pulseLvl > 0)
        {
            pulsing = StartCoroutine(PulseCoroutine());
            pulsestarted = true;
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


    void shoot()
    {
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position,firePoint.rotation);
        if(fireDamageLvl>=1)
        {
            bullet.GetComponent<Bullet>().fire = true;
            bullet.GetComponent<Bullet>().fireDamage = fireDamageLvl*5;
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        if (coneLvl > 1)
        {
            extraCones(coneAngles());
        }
        if (lineLvl > 1)
        {
            extraLines(linePos());
        }
    }

    // helpers for extra cone and line guns from upgrades

    void extraLines(List<float> pos)
    {
        for (int i = 0; i < pos.Count; i++)
        {
            Vector2 offsetVector = Quaternion.Euler(0, 0, 90) * firePoint.up;
            offsetVector *= pos[i];
            Vector3 offsetPosition = firePoint.position + (Vector3)offsetVector;

            GameObject bullet = Instantiate(bulletPreFab, offsetPosition, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    List<float> linePos()
    {
        List<float> pos = new List<float>();
        float interval = 0.25f / (lineLvl - 1);
        for (int i = 1; i < lineLvl; i++)
        {
            pos.Add(i * interval);
            pos.Add(-i * interval);
        }
        return pos;
    }


    void extraCones(List<int> angles)
    {
        for (int i = 0; i < angles.Count; i++)
        {
            Vector2 direction = Quaternion.Euler(0, 0, angles[i]) * firePoint.up;
            GameObject bullet = Instantiate(bulletPreFab, firePoint.position, Quaternion.Euler(0, 0, angles[i]) * firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }
    }

    List<int> coneAngles()
    {
        List<int> angles = new List<int>();
        int interval = 1;
        if (2 <= coneLvl && coneLvl <= 3)
        {
            interval = (int)Math.Round(20f / (coneLvl - 1));
        }
        else if (4 <= coneLvl && coneLvl <= 6)
        {
            interval = (int)Math.Round(45f / (coneLvl - 1));
        }
        else if (7 <= coneLvl && coneLvl <= 9)
        {
            interval = (int)Math.Round(60f / (coneLvl - 1));
        }
        else if (coneLvl > 9)
        {
            interval = (int)Math.Round(75f / (coneLvl - 1));
        }

        for (int i = 1; i < coneLvl; i++)
        {
            angles.Add(i * interval);
            angles.Add(-i * interval);
        }

        return angles;
    }

    // for pulse upgrade

    IEnumerator PulseCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(pulsespdLvl);
            pulseSprite.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            pulseSprite.SetActive(false);
        }
    }

    // Below are upgrades

    public void FireRateUp()
    {
        fireRateLvl += 1;
        firerate = firerate * 1.75f;
    }

    public void ConeLvlUp()
    {
        coneLvl += 1;
    }

    public void LineLvlUp()
    {
        lineLvl += 1;
    }

    public void fireDamageUp()
    {
        fireDamageLvl+=1;
    }

    public void BulletspdLvlUp()
    {
        bulletForce = bulletForce * 2;
        bulletspdLvl += 1;
    }

    public void PulseLvlUp()
    {
        pulseLvl += 1;
    }
}
