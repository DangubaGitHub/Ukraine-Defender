using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    int maxHealth = 5;
    public int currentHealth;
    Animator enemyAnim;
    Rigidbody2D enemyRb;

    [SerializeField] EnemyHeadCounter enemyHeadCounter;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }

        if (currentHealth < 1)
        {
            PlayEnemyDeathAnimation();
            enemyHeadCounter.AddToCounter();
        }
    }

    void PlayEnemyDeathAnimation()
    {
        enemyAnim.SetBool("IsDead", true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyTakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grenade"))
        {
            EnemyTakeDamage(10);
        }
    }
}
