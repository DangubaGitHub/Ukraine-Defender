using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] Animator pipeAnim;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] ParticleSystem bodyHit;

    PauseMenu pauseMenuScript;
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        pauseMenuScript = pauseMenu.GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (!pauseMenuScript.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        AudioManager.instance.PlaySFX(35);

        pipeAnim.ResetTrigger("Hit");
        pipeAnim.SetTrigger("Hit");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            AudioManager.instance.PlaySFX(24);

            enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(3);
           // bodyHit = Instantiate(bodyHit, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
