using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnemy : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] float aggroDistance;
    [SerializeField] Animator enemyAnim;
    Rigidbody2D enemyRb;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerLayer;

    int maxHealth = 5;
    int currentHealth;

    [SerializeField] float timeBetweenHits;
    float nextHitTime;

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

            if (Vector2.Distance(transform.position, target.position) <= minDistance)
            {
                if (Time.time > nextHitTime)
                {
                    Attack();
                    nextHitTime = Time.time + timeBetweenHits;
                }
            }
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }

    void Die()
    {
        enemyAnim.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Attack()
    {
        enemyAnim.ResetTrigger("Hit");
        enemyAnim.SetTrigger("Hit");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach(Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerDamage>().TakeDamage(3);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("Grenade"))
        {
            TakeDamage(10);
        }
    }
}
