using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] Transform player_Idle;


    void Update()
    {
        Vector3 newPosition = player_Idle.position;
        //newPosition.y = transform.position.y;
        newPosition.z = transform.position.z;
       // newPosition.x = transform.position.x;
        transform.position = newPosition;
    }
}
