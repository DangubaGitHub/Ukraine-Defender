using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirSlug : MonoBehaviour
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
        yield return new WaitForSeconds(2f);
        DestroySlug();

    }

    void DestroySlug()
    {
        Destroy(this.gameObject);
    }
}
