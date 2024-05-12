using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{


    public Transform mainMenu;
    public Transform controlMenu;
    public Canvas gameOver;
    public Canvas gamePauseCanvas;


    private bool isPaused = false;

    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == "MenuScene")
        {
            mainMenu.gameObject.SetActive(true);
            controlMenu.gameObject.SetActive(false);
        }

        gamePauseCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
            gamePauseCanvas.gameObject.SetActive(true); // Enable the canvas
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            Debug.Log("Game Resumed");
            gamePauseCanvas.gameObject.SetActive(false); // Disable the canvas
        }
    }


    public void OnPlayButton()
    {
        Time.timeScale = 1f;
        Debug.Log("BUTTON PRESSED");
        SceneManager.LoadScene("MainScene");
    }
    public void OnControlsButton()
    {
        controlMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void OnControlsBackButton()
    {
        mainMenu.gameObject.SetActive(true);
        controlMenu.gameObject.SetActive(false);
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }


}
