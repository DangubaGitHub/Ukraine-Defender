using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickups : MonoBehaviour
{

    Gun gunScript;
    [SerializeField] GameObject player_Gun;

    DoubleGun doubleGunScript;
    [SerializeField] GameObject player_Double_Gun;

    Grenade grenadeScript;
    [SerializeField] GameObject player_Grenad;

    //GearCrate gearCrateScript;
    //[SerializeField] GameObject gearCrate;
    //bool hasPlayer;

    [SerializeField] GameObject add7AmmoPrefab;
    [SerializeField] GameObject ammoMaxPrefab;
    [SerializeField] GameObject add14AmmoPrefab;
    [SerializeField] GameObject add1GrenadePrefab;
    [SerializeField] GameObject grenadeMaxPrefab;

    
    


    private void Awake()
    {
        gunScript = player_Gun.GetComponent<Gun>();
        doubleGunScript = player_Double_Gun.GetComponent<DoubleGun>();
        grenadeScript = player_Grenad.GetComponent<Grenade>();
        //gearCrateScript = gearCrate.GetComponent<GearCrate>();

        
    }

    void Start()
    {
        gunScript.currentAmmo = gunScript.maxAmmo;
        doubleGunScript.currentDoubleAmmo = doubleGunScript.maxDoubleAmmo;
        grenadeScript.currentGrenade = grenadeScript.maxGrenade;
    }

    void Update()
    {
      //  if(/*hasPlayer &&*/ Input.GetKeyDown("e") )
      //  {
      //      gearCrateScript.OpenCrate();
            
      //  }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Gun Ammo"))
        {
            if (gunScript.currentAmmo < 7)
            {
                GameObject ammo7Add = Instantiate(add7AmmoPrefab, transform.position, Quaternion.identity);
                ammo7Add.GetComponentInChildren<TextMeshPro>();

                gunScript.currentAmmo += 7;
                gunScript.UpdateAmmoCount();

                
            }

            else //(gunScript.currentAmmo > 7)
            {
                

                gunScript.currentAmmo = gunScript.maxAmmo;
                gunScript.UpdateAmmoCount();

                GameObject gunAmmoMax = Instantiate(ammoMaxPrefab, transform.position, Quaternion.identity);
                gunAmmoMax.GetComponentInChildren<TextMeshPro>();
            }

            Destroy(other.gameObject);
        }

        if(other.CompareTag("Double Gun Ammo"))
        {
            if(doubleGunScript.currentDoubleAmmo < 14)
            {
                GameObject ammo14Add = Instantiate(add14AmmoPrefab, transform.position, Quaternion.identity);
                ammo14Add.GetComponentInChildren<TextMeshPro>();

                doubleGunScript.currentDoubleAmmo += 14;
                doubleGunScript.UpdateDoubleAmmoCount();

               
            }

            else //if(doubleGunScript.currentDoubleAmmo > 14)
            {
                

                doubleGunScript.currentDoubleAmmo = doubleGunScript.maxDoubleAmmo;
                doubleGunScript.UpdateDoubleAmmoCount();

                GameObject gunAmmoMax = Instantiate(ammoMaxPrefab, transform.position, Quaternion.identity);
                gunAmmoMax.GetComponentInChildren<TextMeshPro>();
            }

            Destroy(other.gameObject);
        }

        if(other.CompareTag("Grenade Ammo"))
        {
            if(grenadeScript.currentGrenade < 2)
            {
                GameObject grenade1Add = Instantiate(add1GrenadePrefab, transform.position, Quaternion.identity);
                grenade1Add.GetComponentInChildren<TextMeshPro>();

                grenadeScript.currentGrenade += 1;
                grenadeScript.UpdateGrenadeCount();

                
            }

            else //if(grenadeScript.currentGrenade >= 2)
            {
                grenadeScript.currentGrenade = grenadeScript.maxGrenade;
                grenadeScript.UpdateGrenadeCount();

                GameObject grenadeMax = Instantiate(grenadeMaxPrefab, transform.position, Quaternion.identity);
                grenadeMax.GetComponentInChildren<TextMeshPro>();
            }


            Destroy(other.gameObject);
        }

        //if(other.CompareTag("Gear Crate"))
        //{
        //    hasPlayer = true;
       // }
    }

   /* private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Gear Crate"))
        {
            hasPlayer = false;
        }
    }*/
}
