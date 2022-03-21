using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Animator grenadeAnim;
    [SerializeField] Transform throwPoint;
    [SerializeField] float throwForce;
    [SerializeField] Text grenadeText;
    [SerializeField] int maxGrenade;
    [SerializeField] int currentGrenade;

    [SerializeField] float timeBetweenShots;
    float nextShotTime;

    void Start()
    {
        currentGrenade = 3;
        UpdateGrenadeCount();
    }

    void Update()
    {
        if (currentGrenade > 0)
        {
            if (Input.GetButtonDown("Fire2") && Time.time > nextShotTime)
            {
                    
                Invoke("Throw", .5f);

                grenadeAnim.ResetTrigger("Throw");
                grenadeAnim.SetTrigger("Throw");

                currentGrenade--;
                UpdateGrenadeCount();

                nextShotTime = Time.time + timeBetweenShots;
            }

        }
    }

    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();
        grenadeRb.AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }

    void UpdateGrenadeCount()
    {
        grenadeText.text = currentGrenade.ToString();
    }
}
