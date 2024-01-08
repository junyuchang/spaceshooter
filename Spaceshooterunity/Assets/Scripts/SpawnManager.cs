using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float mobCheckInterval = 5f;
    private GameObject mobCheck;
    private float interval=0;
    public GameObject[] spawners = new GameObject[5];
    public int waves = 2;
    // Start is called before the first frame update
    void Start()
    {
        interval = mobCheckInterval;
    }

    // Update is called once per frame
    void Update()
    {
        mobCheckInterval-=Time.deltaTime;
        if(mobCheckInterval<= 0)
        {
            mobCheck = GameObject.Find("Melee(Clone)");
            Debug.Log(mobCheck);
            if(mobCheck == null && waves>0)
            {
                TriggerSpawners();
                waves-=1;
            } 
            mobCheckInterval = interval;
        }
    }
    void TriggerSpawners()
    {
        foreach(GameObject spawner in spawners)
        {
            spawner.GetComponent<Spawner>().TriggerSpawner();
        }
    }
}
