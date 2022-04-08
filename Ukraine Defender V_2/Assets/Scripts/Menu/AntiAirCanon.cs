using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirCanon : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject slugPrefab;
    [SerializeField] float slugSpeed;

    [SerializeField] float minWaitBetweenPlays;
    [SerializeField] float maxWaitBetweenPlays;
    [SerializeField] float waitTimeCountdow;

    void Start()
    {
        
    }

    void Update()
    {
        if (waitTimeCountdow < 0)
        {
            CanonFire();
            waitTimeCountdow = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
        }
        else
        {
            waitTimeCountdow -= Time.deltaTime;
        }
    }

    void CanonFire()
    {
        GameObject slug = Instantiate(slugPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D slugRB = slug.GetComponent<Rigidbody2D>();
        slugRB.AddForce(firePoint.up * slugSpeed, ForceMode2D.Impulse);

        MenuAudioManager.instance.PlaySFX(1);
    }
}
