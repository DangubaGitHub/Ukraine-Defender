using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenu;

    [SerializeField] GameObject pauseScreen;
    public bool isPaused;

    FadeScreen fadeScreenScript;
    [SerializeField] GameObject fadeScreen;

    private void Awake()
    {
        fadeScreenScript = fadeScreen.GetComponent<FadeScreen>();
        isPaused = false;
    }

    void Start()
    {
        fadeScreenScript.FadeFromBlack();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            AudioManager.instance.PlaySFX(37);
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            
            isPaused = true;
            
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySFX(37);
        fadeScreenScript.FadeToRed();
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }
}
