using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : MonoBehaviour
{

    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ParticleSystem muzzleFlash1;
    [SerializeField] ParticleSystem muzzleflash2;
    [SerializeField] float bulletForce;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot1();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            Shoot2();
        }
    }

    void Shoot1()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash1();
    }

    void Shoot2()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash2();
    }

    void EmitMuzzleFlash1()
    {
        muzzleFlash1.Emit(3);
    }

    void EmitMuzzleFlash2()
    {
        muzzleflash2.Emit(3);
    }
}
