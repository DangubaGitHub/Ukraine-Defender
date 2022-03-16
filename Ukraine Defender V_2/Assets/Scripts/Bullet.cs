using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] ParticleSystem metalHit;
    [SerializeField] ParticleSystem woodHit;
    [SerializeField] ParticleSystem concreteHit;
    [SerializeField] ParticleSystem bodyHit;
    [SerializeField] ParticleSystem bulletHit;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Concrete"))
        {
            concreteHit = Instantiate(concreteHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Wood"))
        {
            woodHit = Instantiate(woodHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Metal"))
        {
            metalHit = Instantiate(metalHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Body"))
        {
            bodyHit = Instantiate(bodyHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletHit = Instantiate(bulletHit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
