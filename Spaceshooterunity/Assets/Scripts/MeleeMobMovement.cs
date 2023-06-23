using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMobMovement : MonoBehaviour
{
    //Base speed
    float speed;
    public float speedValue = 1f;
    public GameObject player;

    public Rigidbody2D rb;

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        speed = speedValue;
    }

    // Update is called once per frame
    void Update()
    {
        
        dir = player.transform.position - gameObject.transform.position;
        Vector3.Normalize(dir);
        transform.Translate(dir*Time.deltaTime*speed);
        
    }
}
