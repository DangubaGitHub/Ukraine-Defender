using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TruckExplosion : MonoBehaviour
{
    [SerializeField] Animator carAnim;
    [SerializeField] string mainMenu;

    [SerializeField] Image endFadeScreen;
    [SerializeField] Text endTextScreen1;
    [SerializeField] Text endTextScreen2;
    [SerializeField] float endFadeScreenSpeed;

    bool endFade;

    void Start()
    {

    }

    void Update()
    {
        if(endFade)
        {
            endFadeScreen.color = new Color(endFadeScreen.color.r, endFadeScreen.color.g, endFadeScreen.color.b, Mathf.MoveTowards(endFadeScreen.color.a, 1f, endFadeScreenSpeed * Time.deltaTime));

            if (endFadeScreen.color.a == 1f)
            {
                endFade = false;
            }

            endTextScreen1.color = new Color(endTextScreen1.color.r, endTextScreen1.color.g, endTextScreen1.color.b, Mathf.MoveTowards(endTextScreen1.color.a, 1f, endFadeScreenSpeed * Time.deltaTime));
            endTextScreen2.color = new Color(endTextScreen2.color.r, endTextScreen2.color.g, endTextScreen2.color.b, Mathf.MoveTowards(endTextScreen2.color.a, 1f, endFadeScreenSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grenade"))
        {
            carAnim.ResetTrigger("Exploded");
            carAnim.SetTrigger("Exploded");

            Invoke("EndFade", .5f);

            StartCoroutine(DelayLevelEnd());
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }

    IEnumerator DelayLevelEnd()
    {
        yield return new WaitForSeconds(5f);
        LoadMenu();

    }

    void EndFade()
    {
        endFade = true;
    }
}
