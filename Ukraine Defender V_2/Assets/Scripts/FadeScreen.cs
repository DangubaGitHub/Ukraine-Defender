using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

    [SerializeField] Image fadeScreenBlack;
    [SerializeField] Image fadeScreenRed;
    [SerializeField] Text fadeTextGameOver;

    [SerializeField] float fadeSpeedBlack;
    [SerializeField] float fadeSpeedRed;

    bool shouldFadeToBlack;
    bool shouldFadeFromBlack;
    bool shouldFadeToRed;
    //bool shouldFadeText;


    void Start()
    {
        FadeFromBlack();
    }


    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeScreenBlack.color = new Color(fadeScreenBlack.color.r, fadeScreenBlack.color.g, fadeScreenBlack.color.b, Mathf.MoveTowards(fadeScreenBlack.color.a, 1f, fadeSpeedBlack * Time.deltaTime));

            if(fadeScreenBlack.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreenBlack.color = new Color(fadeScreenBlack.color.r, fadeScreenBlack.color.g, fadeScreenBlack.color.b, Mathf.MoveTowards(fadeScreenBlack.color.a, 0f, fadeSpeedBlack * Time.deltaTime));

            if (fadeScreenBlack.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }

        if(shouldFadeToRed)
        {
            fadeScreenRed.color = new Color(fadeScreenRed.color.r, fadeScreenRed.color.g, fadeScreenRed.color.b, Mathf.MoveTowards(fadeScreenRed.color.a, 1f, fadeSpeedRed * Time.deltaTime));

            if (fadeScreenRed.color.a == 1f)
            {
                shouldFadeToRed = false;
            }

            fadeTextGameOver.color = new Color(fadeTextGameOver.color.r, fadeTextGameOver.color.g, fadeTextGameOver.color.b, Mathf.MoveTowards(fadeTextGameOver.color.a, 1f, fadeSpeedRed * Time.deltaTime));

            if(fadeTextGameOver.color.a == 1f)
            {
                //shouldFadeText = false;
            }

           
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void FadeToRed()
    {
        shouldFadeToRed = true;
        //shouldFadeText = true;
    }
}
