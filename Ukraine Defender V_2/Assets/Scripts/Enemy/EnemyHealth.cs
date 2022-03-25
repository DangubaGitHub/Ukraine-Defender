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

    public int currentHeadCount;
    [SerializeField] Text headCountText;

    public bool isDead;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentHeadCount = 0;
        UpdateHeadCount();
    }

    void Update()
    {

        if (currentHealth <= 0)
        {
            if (!isDead)
            {
                EnemyDeath();
                AddToCounter();
                Debug.Log("Counter added");
                

            }
            isDead = true;
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (currentHealth > 0)
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grenade"))
        {
            EnemyTakeDamage(10);
        }
    }

    public void UpdateHeadCount()
    {
        headCountText.text = currentHeadCount.ToString();
    }

    public void AddToCounter()
    {
            currentHeadCount++;
            UpdateHeadCount();
    } 
}
