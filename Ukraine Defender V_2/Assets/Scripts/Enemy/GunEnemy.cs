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
    [SerializeField] Animator enemyAnim;

    [SerializeField] EnemyHealth enemyHealthScript;

    PlayerDamage playerDamageScript;
    [SerializeField] GameObject playerDamage;

    private void Awake()
    {
        playerDamageScript = playerDamage.GetComponent<PlayerDamage>();
    }

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerDamageScript.currentHealth > 0)
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

                    AudioManager.instance.PlaySFX(22);

                    nextShotTime = Time.time + timeBetweenShots;
                }
            }
        }

        if(enemyHealthScript.currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void EmitMuzzleFlash()
    {
        muzzleFlash.Emit(3);
    }
}