using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGunEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] float aggroDistance;
    Rigidbody2D enemyRb;
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] ParticleSystem muzzleFlash1;
    [SerializeField] ParticleSystem muzzleFlash2;
    [SerializeField] float timeBetweenShots;
    float nextShotTime;
    [SerializeField] Animator enemyAnim;
    [SerializeField] EnemyHealth enemyHealthScript;

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
                Shoot1();
                Invoke("Shoot2", .1f); 

                nextShotTime = Time.time + timeBetweenShots;
            }

        }

        if(enemyHealthScript.currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Shoot1()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash1();
    }

    void EmitMuzzleFlash1()
    {
        muzzleFlash1.Emit(3);
    }

    void Shoot2()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        EmitMuzzleFlash2();
    }

    void EmitMuzzleFlash2()
    {
        muzzleFlash2.Emit(3);
    }
}
