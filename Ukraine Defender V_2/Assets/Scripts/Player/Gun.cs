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
    public int maxAmmo;
    public int currentAmmo;
    public Text ammoText;

    PauseMenu pauseMenuScript;
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoCount();

        pauseMenuScript = pauseMenu.GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (!pauseMenuScript.isPaused)
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

    public void UpdateAmmoCount()
    {
        ammoText.text = currentAmmo.ToString();
    }
}
