using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectiveScene : MonoBehaviour
{
    [SerializeField] Image fadeScreen;
    [SerializeField] float fadespeed;
    bool shouldFadeToBlack;
    bool shouldFadeFromBlack;

    [SerializeField] string startGame;

    void Start()
    {
        FadeFromBlack();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FadeToBlack();
            StartCoroutine(DelayStart());
        }

        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadespeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadespeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    void FadeToBlack()
    {
        shouldFadeToBlack = true;
    }

    void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
    }

    void StartGame()
    {
        SceneManager.LoadScene(startGame);

    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1);
        StartGame();
    }
}
