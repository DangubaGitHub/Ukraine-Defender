using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    Gun gunScript;
    [SerializeField] GameObject player_Gun;

    void Start()
    {
        gunScript = player_Gun.GetComponent<Gun>();
    }

    void Update()
    {
        
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
    }
}
