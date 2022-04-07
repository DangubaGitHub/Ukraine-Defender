using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    Animator playerAnim;
    Rigidbody2D playerRb;

    FadeScreen fadeScreenScript;
    [SerializeField] GameObject fadeScreen;

    public string mainMenu;

    

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();

        fadeScreenScript = fadeScreen.GetComponent<FadeScreen>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentArmor = maxArmor;
        armorBar.SetMaxArmor(maxArmor);
    }

    void Update()
    {
        //if (currentHealth < 1)
        //{
       //     PlayerDeath();
       // }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {

            AudioManager.instance.PlaySFX(Random.Range(1, 2));
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentArmor > 0)
        {
            currentArmor -= damage;
            //AudioManager.instance.PlaySFX(Random.Range(1, 2));

            armorBar.SetArmor(currentArmor);
        }
        else
        {
            currentHealth -= damage;
            

            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth < 1)
        {

          

            fadeScreenScript.FadeToRed();
            PlayerDeath();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Health"))
        {
            AudioManager.instance.PlaySFX(23);

            healthBar.SetHealth(maxHealth);
            currentHealth = maxHealth;
            Destroy(other.gameObject);

            GameObject addMaxHealth = Instantiate(maxHealthPrefab, transform.position, Quaternion.identity);
            addMaxHealth.GetComponentInChildren<TextMeshPro>();
        }

        if(other.CompareTag("Armor"))
        {
            AudioManager.instance.PlaySFX(0);

            armorBar.SetArmor(maxArmor);
            currentArmor = maxArmor;
            Destroy(other.gameObject);

            GameObject addMaxArmor = Instantiate(maxArmorPrefab, transform.position, Quaternion.identity);
            addMaxArmor.GetComponentInChildren<TextMeshPro>();
        }
    }

    public void PlayerDeath()
    {

        
        AudioManager.instance.PlaySFX(30);
            
       
        
        playerAnim.SetBool("IsDead", true);
        playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<WeaponSwitching>().enabled = false;

        StartCoroutine(DelayManu());
    }

     IEnumerator DelayManu()
     {
         yield return new WaitForSeconds(2.5f);
         SceneManager.LoadScene(mainMenu);
     }
}
