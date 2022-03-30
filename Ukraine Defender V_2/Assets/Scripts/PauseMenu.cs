using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenu;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] bool isPaused;

    void Start()
    {
       
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
            pauseScreen.SetActive(false);
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
