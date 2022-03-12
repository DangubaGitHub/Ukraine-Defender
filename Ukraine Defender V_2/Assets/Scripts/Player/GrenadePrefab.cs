using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePrefab : MonoBehaviour
{

    [SerializeField] Collider2D circleCollider;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Explosion()
    {

    }

    void ActivateCollider()
    {
        circleCollider.enabled = true;
    }
}
