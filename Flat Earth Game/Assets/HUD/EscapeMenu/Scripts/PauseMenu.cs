using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenuUI;

    public bool isOptionsMenuOpen;

    private void Start()
    {
        isOptionsMenuOpen = false;
    }



    // Update is called once per frame
    void Update () {

        if(optionsMenuUI.activeSelf == true)
        {
            isOptionsMenuOpen = true;
        }
        else
        {
            isOptionsMenuOpen = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isOptionsMenuOpen)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOptionsMenuOpen)
        {
            optionsMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
	}

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
