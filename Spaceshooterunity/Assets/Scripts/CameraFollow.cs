using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    void Start()
    {
        // Calculate initial offset
        offset = transform.position - target.position;

    }

    void LateUpdate()
    {
        // update camera position to be target position with offset
        transform.position = target.position + offset;
    }
}
