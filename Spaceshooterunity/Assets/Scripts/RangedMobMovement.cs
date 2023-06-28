using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMobMovement : MonoBehaviour
{
    //Base speed
    float speed;
    public float speedValue = 1f;
    public GameObject player;
    public Rigidbody2D rb;
    public float spacing = 3.0f;

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

        // doesn't move when player is less than a certain distance from the mob
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        // Rotate facing player
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (distance > spacing)
        {
            dir = Vector3.Normalize(dir);
            transform.Translate(dir * Time.deltaTime * speed, Space.World);
        }



    }
}
