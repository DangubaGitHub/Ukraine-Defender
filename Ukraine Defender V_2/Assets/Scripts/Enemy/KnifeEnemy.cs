using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] float aggroDistance;
    [SerializeField] Animator knifeSlash;
    Rigidbody2D enemyRb;

    [SerializeField] EnemyHealth enemyHealthScript;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float timeBetweenHits;
    float nextHitTime;

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

                if (Vector2.Distance(transform.position, target.position) <= minDistance)
                {
                    if (Time.time > nextHitTime)
                    {
                        Attack();
                        nextHitTime = Time.time + timeBetweenHits;
                    }
                }
            }
        }

        if (enemyHealthScript.currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Attack()
    {
        AudioManager.instance.PlaySFX(33);

        knifeSlash.ResetTrigger("Slash");
        knifeSlash.SetTrigger("Slash");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            AudioManager.instance.PlaySFX(24);
            player.GetComponent<PlayerDamage>().TakeDamage(5);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
