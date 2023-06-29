// Taken from https://www.youtube.com/watch?v=9dYDBomQpBQ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void pauseResumeTime()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseResumeTime();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseResumeTime();
    }
}
