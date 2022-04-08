using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirMachineGun : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    [SerializeField] float minWaitBetweenShots;
    [SerializeField] float maxWaitBetweenShots;
    [SerializeField] float WaitTimeCountdown;

    void Start()
    {
        
    }

    void Update()
    {
        if(WaitTimeCountdown < 0)
        {
            MachineGunFire();
            Invoke("MachineGunFire", .05f);
            Invoke("MachineGunFire", .1f);
            Invoke("MachineGunFire", .15f);
            Invoke("MachineGunFire", .2f);
            Invoke("MachineGunFire", .25f); 
            Invoke("MachineGunFire", .3f);

            WaitTimeCountdown = Random.Range(minWaitBetweenShots, maxWaitBetweenShots);
        }
        else
        {
            WaitTimeCountdown -= Time.deltaTime;
        }
    }

    void MachineGunFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        MenuAudioManager.instance.PlaySFX(2);
    }
}
