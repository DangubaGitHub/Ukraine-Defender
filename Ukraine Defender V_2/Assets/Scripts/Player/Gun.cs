using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] ParticleSystem muzzleFlash;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash();
    }

    void EmitMuzzleFlash()
    {
        muzzleFlash.Emit(3);
    }
}
