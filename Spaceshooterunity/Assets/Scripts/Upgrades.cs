using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject player;

    public void FireRateUp()
    {
        Shooting shootingcomponent = player.GetComponent<Shooting>();
        shootingcomponent.FireRateUp();
    }

}
