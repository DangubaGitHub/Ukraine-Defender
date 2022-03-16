using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpeed;
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 position = player.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, position, followSpeed);
        transform.position = smoothed;
    }
}
