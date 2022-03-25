using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour
{

    public HealthBar healthBar;
    public ArmorBar armorBar;
    public int currentHealth;
    public int currentArmor;
    public int maxHealth = 5;
    public int maxArmor = 5;

    [SerializeField] GameObject maxHealthPrefab;
    [SerializeField] GameObject maxArmorPrefab;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentArmor = maxArmor;
        armorBar.SetMaxArmor(maxArmor);
    }

    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentArmor > 0)
        {
            currentArmor -= damage;

            armorBar.SetArmor(currentArmor);
        }
        else
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Health"))
        {
            healthBar.SetHealth(maxHealth);
            currentHealth = maxHealth;
            Destroy(other.gameObject);

            GameObject addMaxHealth = Instantiate(maxHealthPrefab, transform.position, Quaternion.identity);
            addMaxHealth.GetComponentInChildren<TextMeshPro>();
        }

        if(other.CompareTag("Armor"))
        {
            armorBar.SetArmor(maxArmor);
            currentArmor = maxArmor;
            Destroy(other.gameObject);

            GameObject addMaxArmor = Instantiate(maxArmorPrefab, transform.position, Quaternion.identity);
            addMaxArmor.GetComponentInChildren<TextMeshPro>();
        }
    }
}
