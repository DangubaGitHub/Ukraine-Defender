using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] string Objectives;

    FadeScreen fadeScreenScript;
    [SerializeField] GameObject fadeScreen;

    private void Awake()
    {
        fadeScreenScript = fadeScreen.GetComponent<FadeScreen>();
    }

    void Start()
    {
        fadeScreenScript.FadeToBlack();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        fadeScreenScript.FadeToBlack();
        //SceneManager.LoadScene(startGame);
        StartCoroutine(DelayPlay());
    }

    public void QuitGame()
    {
        fadeScreenScript.FadeToRed();
        StartCoroutine(DelayQuit());
    }

    IEnumerator DelayPlay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Objectives);
    }

    IEnumerator DelayQuit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
        Debug.Log("Game Quitted");
    }
}
