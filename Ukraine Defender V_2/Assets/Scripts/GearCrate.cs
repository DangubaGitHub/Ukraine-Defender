using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCrate : MonoBehaviour
{
    [SerializeField] Animator crateAnim;

    Gun gunScript;
    [SerializeField] GameObject player_Gun;

    DoubleGun doubleGunScript;
    [SerializeField] GameObject player_Double_Gun;

    Grenade grenadeScript;
    [SerializeField] GameObject player_Grenad;

    PlayerDamage playerDamageScript;
    [SerializeField] GameObject playerDamage;

    public bool hasPlayer;
    public bool crateIsOpen;

    private void Awake()
    {
        
        gunScript = player_Gun.GetComponent<Gun>();

        
        doubleGunScript = player_Double_Gun.GetComponent<DoubleGun>();

        
        grenadeScript = player_Grenad.GetComponent<Grenade>();

        
        playerDamageScript = playerDamage.GetComponent<PlayerDamage>();
    }

    void Start()
    {
      
    }

    void Update()
    {
        if (hasPlayer && Input.GetKeyDown("e"))
        {
            if (!crateIsOpen)
            {
                
                OpenCrate();
               
            }

            else
            {
                CrateUsed();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }

    public void OpenCrate()
    {
            crateAnim.ResetTrigger("CrateOpen");
            crateAnim.SetTrigger("CrateOpen");

            playerDamageScript.healthBar.SetHealth(playerDamageScript.maxHealth);
            playerDamageScript.currentHealth = playerDamageScript.maxHealth;

            playerDamageScript.armorBar.SetArmor(playerDamageScript.maxArmor);
            playerDamageScript.currentArmor = playerDamageScript.maxArmor;

            gunScript.currentAmmo = gunScript.maxAmmo;
            gunScript.UpdateAmmoCount();

            doubleGunScript.currentDoubleAmmo = doubleGunScript.maxDoubleAmmo;
            doubleGunScript.UpdateDoubleAmmoCount();

            grenadeScript.currentGrenade = grenadeScript.maxGrenade;
            grenadeScript.UpdateGrenadeCount();

            crateIsOpen = true;
    }

    void CrateUsed()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
