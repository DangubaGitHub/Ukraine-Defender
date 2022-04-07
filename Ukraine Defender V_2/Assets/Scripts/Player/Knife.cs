using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    [SerializeField] Animator knifeAnim;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
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
        AudioManager.instance.PlaySFX(33);

        knifeAnim.ResetTrigger("Slash");
        knifeAnim.SetTrigger("Slash");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            AudioManager.instance.PlaySFX(24);
            enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(5);
            //bodyHit = Instantiate(bodyHit, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
