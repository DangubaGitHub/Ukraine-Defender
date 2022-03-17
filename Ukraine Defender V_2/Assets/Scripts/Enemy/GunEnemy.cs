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

    [SerializeField] int currentHealth;
    int maxHealth = 4;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
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
            }
        }
    }

    void EmitMuzzleFlash()
    {
        muzzleFlash.Emit(3);
    }

    void TakeDamage(int damage)
    {
         if (currentHealth > 0)
         {
             currentHealth -= damage;
         }

         else if(currentHealth <= 0)
         {
             Destroy(gameObject);
         }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.CompareTag("Bullet"))
         {
             TakeDamage(1);
         }

         if (other.gameObject.CompareTag("Knife"))
         {
             TakeDamage(5);
         }

         if (other.gameObject.CompareTag("Pipe"))
         {
             TakeDamage(3);
         }

         if (other.gameObject.CompareTag("Grenade"))
         {
             TakeDamage(10);
         }
    }
}
