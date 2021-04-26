using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelMenuManager : MonoBehaviour {

    private int levelNum;

    public GameObject[] panels;

    public void Update()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        levelNum = data.levelNumber;
        Panel();
    }

    public void LevelLoader(int level)
    {
        if (level <= levelNum)
        {
            FindObjectOfType<AudioManager>().Play("button");
            SceneManager.LoadScene("Level_" + level);
        }
    }

    public void LevelLoader()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene("Level_" + levelNum);
    }

    public void Panel()
    {
        for (int i=0; i<panels.Length; i++)
        {
            if (i < levelNum)
            {
                panels[i].SetActive(false);
            }
        }
    }
}
