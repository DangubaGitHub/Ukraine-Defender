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

    [SerializeField] float timeBetweenHits;
    float nextHitTime;

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

            if (Vector2.Distance(transform.position, target.position) <= minDistance)
            {
                if (Time.time > nextHitTime)
                {
                    Attack();
                    nextHitTime = Time.time + timeBetweenHits;
                }
            }
        }

        if(enemyHealthScript.currentHealth <= 0 && enemyHealthScript.isDead)
        {
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
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
}
