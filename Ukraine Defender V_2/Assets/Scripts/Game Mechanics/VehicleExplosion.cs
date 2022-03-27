using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleExplosion : MonoBehaviour
{
    [SerializeField] Animator carAnim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grenade"))
        {
            carAnim.ResetTrigger("Exploded");
            carAnim.SetTrigger("Exploded");
        }
    }
}
