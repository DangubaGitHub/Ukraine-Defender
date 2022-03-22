using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    


    private void Awake()
    {
        gunScript = player_Gun.GetComponent<Gun>();
        doubleGunScript = player_Double_Gun.GetComponent<DoubleGun>();
        grenadeScript = player_Grenad.GetComponent<Grenade>();
        //gearCrateScript = gearCrate.GetComponent<GearCrate>();
    }

    void Start()
    {
        
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
            if (gunScript.currentAmmo <= 7)
            {
                gunScript.currentAmmo += 7;
                gunScript.UpdateAmmoCount();
            }

            else if(gunScript.currentAmmo >= 7)
            {
                gunScript.currentAmmo = gunScript.maxAmmo;
                gunScript.UpdateAmmoCount();
            }

            Destroy(other.gameObject);
        }

        if(other.CompareTag("Double Gun Ammo"))
        {
            if(doubleGunScript.currentDoubleAmmo <= 14)
            {
                doubleGunScript.currentDoubleAmmo += 14;
                doubleGunScript.UpdateDoubleAmmoCount();
            }

            else if(doubleGunScript.currentDoubleAmmo > 14)
            {
                doubleGunScript.currentDoubleAmmo = doubleGunScript.maxDoubleAmmo;
                doubleGunScript.UpdateDoubleAmmoCount();
            }

            Destroy(other.gameObject);
        }

        if(other.CompareTag("Grenade Ammo"))
        {
            if(grenadeScript.currentGrenade <= 2)
            {
                grenadeScript.currentGrenade += 1;
                grenadeScript.UpdateGrenadeCount();
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
