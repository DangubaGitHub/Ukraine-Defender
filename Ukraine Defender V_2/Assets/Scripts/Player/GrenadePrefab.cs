using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePrefab : MonoBehaviour
{

    [SerializeField] Collider2D circleCollider;
    [SerializeField] ParticleSystem shrapnel;
    [SerializeField] ParticleSystem blast;
    [SerializeField] ParticleSystem smoke;

    void Start()
    {
        
    }

    void Update()
    {
        Invoke("Explosion", .5f);
        Invoke("DestroyGrenade", .57f);
    }

    void Explosion()
    {
        //Invoke("EnableCollider", .5f);
        circleCollider.enabled = true;
        EmitExplosion();

        AudioManager.instance.PlaySFX(19);
    }

    void EmitExplosion()
    {
        blast = Instantiate(blast, transform.position, Quaternion.identity);
        shrapnel = Instantiate(shrapnel, transform.position, Quaternion.identity);
        smoke = Instantiate(smoke, transform.position, Quaternion.identity);
    }

    void DestroyGrenade()
    {
       
        Destroy(gameObject);
    }

    void EnableCollider()
    {
        
    }
}
