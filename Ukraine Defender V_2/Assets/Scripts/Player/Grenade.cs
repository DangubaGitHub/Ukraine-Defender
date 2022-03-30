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
    public Text grenadeText;
    public int maxGrenade;
    public int currentGrenade;
    

    [SerializeField] float timeBetweenShots;
    float nextShotTime;

    PauseMenu pauseMenuScript;
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        currentGrenade = 3;
        UpdateGrenadeCount();

        pauseMenuScript = pauseMenu.GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (!pauseMenuScript.isPaused)
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
    }

    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();
        grenadeRb.AddForce(throwPoint.up * throwForce, ForceMode2D.Impulse);
    }

    public void UpdateGrenadeCount()
    {
        grenadeText.text = currentGrenade.ToString();
    }
}
