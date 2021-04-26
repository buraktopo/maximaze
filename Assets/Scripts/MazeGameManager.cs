using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGameManager : MonoBehaviour {


    public void EndGame()
    {

        LoadLevel("GoldenRoom");
    }

    public void LoadLevel(string name)
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(name);

    }

    public void QuitRequest()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }

}
