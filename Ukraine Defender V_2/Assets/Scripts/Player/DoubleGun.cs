using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleGun : MonoBehaviour
{

    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] ParticleSystem muzzleFlash1;
    [SerializeField] ParticleSystem muzzleflash2;
    [SerializeField] float bulletForce;

    public Text doubleGunAmmoText;
    public int maxDoubleAmmo;
    public int currentDoubleAmmo;

    

    void Start()
    {
        currentDoubleAmmo = maxDoubleAmmo;
        UpdateDoubleAmmoCount();
    }

    void Update()
    {
        if (currentDoubleAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot1();

                currentDoubleAmmo--;
                UpdateDoubleAmmoCount();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Shoot2();

                currentDoubleAmmo--;
                UpdateDoubleAmmoCount();
            }
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

    public void UpdateDoubleAmmoCount()
    {
        doubleGunAmmoText.text = currentDoubleAmmo.ToString();
    }
}
