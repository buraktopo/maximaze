using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject EndgameMenuUI;
    public GameObject PauseButton;

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        FindObjectOfType<AudioManager>().Play("button");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HandleLevelMenuButtonOnClickEvent()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene("LevelMenu");
    }

    public void HandleQuitButtonOnClickEvent()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene("MainMenu");
    }

    public void HandleEndgameLevelLoadButtonOnClickEvent(string name)
    {
        EndgameMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(name);
    }
}
