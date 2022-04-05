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

    public PlayerDamage playerDamage;


    void Start()
    {
        playerDamage = GameObject.Find("Player_Idle").GetComponent<PlayerDamage>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Concrete"))
        {
            concreteHit = Instantiate(concreteHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(2, 5));

            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Wood"))
        {
            woodHit = Instantiate(woodHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(10, 12));

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Metal"))
        {
            metalHit = Instantiate(metalHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(6, 9));

            Destroy(gameObject);
            
        }

        if (collision.gameObject.CompareTag("Gear Crate"))
        {
            metalHit = Instantiate(metalHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(8, 9));

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Body"))
        {
            bodyHit = Instantiate(bodyHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(1, 2));

            Destroy(gameObject); 
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            bodyHit = Instantiate(bodyHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(1, 2));

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletHit = Instantiate(bulletHit, transform.position, Quaternion.identity);

            BulletAudioManager.instance.PlayBulletSFX(Random.Range(6, 7));

            Destroy(gameObject);
        }
    }

   
}
