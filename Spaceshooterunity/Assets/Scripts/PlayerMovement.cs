//Taken from https://medium.com/@chamo.wijetunga/movement-of-a-2d-player-in-unity-aff2b8f02fb5
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Base speed
    public Vector2 speed = new Vector2(50,50);

    //Camera
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
        Debug.Log(speed.x * inputX);
        movement *= Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotate facing the mouse
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
