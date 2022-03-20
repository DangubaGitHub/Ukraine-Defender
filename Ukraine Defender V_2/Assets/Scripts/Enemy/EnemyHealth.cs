using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    int maxHealth = 5;
    public int currentHealth;
    Animator enemyAnim;
    Rigidbody2D enemyRb;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        
        if(currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }

    void EnemyDeath()
    {
        enemyAnim.SetBool("IsDead", true);

      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyTakeDamage(1);
        }

        if (other.gameObject.CompareTag("Grenade"))
        {
            EnemyTakeDamage(10);
        }
    }
}
