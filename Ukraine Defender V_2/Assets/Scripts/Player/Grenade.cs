using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Animator grenadeAnim;
    [SerializeField] Transform throwPoint;
    [SerializeField] float throwForce;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Invoke ("Throw", .5f);

            grenadeAnim.ResetTrigger("Throw");
            grenadeAnim.SetTrigger("Throw");
        }
    }

    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();
        grenadeRb.AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }
}
