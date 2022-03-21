using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int maxAmmo;
    [SerializeField] int currentAmmo;
    [SerializeField] Text ammoText;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoCount();
    }

    void Update()
    {
        if (currentAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();

                currentAmmo--;
                UpdateAmmoCount();
            }
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

    void UpdateAmmoCount()
    {
        ammoText.text = currentAmmo.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gun Ammo Pickup");
        if (other.CompareTag("Gun Ammo"))
        {
            Debug.Log("Gun Ammo Pickup");
            //currentAmmo += 7;
            //UpdateAmmoCount();
            //Destroy(other.gameObject);
        }
    }
}
