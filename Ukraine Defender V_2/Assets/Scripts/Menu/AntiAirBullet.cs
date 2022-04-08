using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirBullet : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DelayDestroy());   
    }

    void Update()
    {
       
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(5f);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
