using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] float aggroDistance;
    Rigidbody2D enemyRb;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float timeBetweenShots;
    float nextShotTime;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < aggroDistance)
        {
            Vector2 lookDir = target.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            enemyRb.rotation = angle;

            if (Vector2.Distance(transform.position, target.position) > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, target.position) < minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);
            }

           
            
                if (Time.time > nextShotTime)
                {
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                    bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                    EmitMuzzleFlash();

                    nextShotTime = Time.time + timeBetweenShots;
                    //Shoot();
                    
                }
            
        }
    }

    /*void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash();
    }*/

    void EmitMuzzleFlash()
    {
        muzzleFlash.Emit(3);
    }
}
