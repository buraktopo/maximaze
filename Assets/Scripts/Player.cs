using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [HideInInspector]
    public int levelNum = 1;
    private bool levelPassed;


    static Player instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (levelPassed == true && SceneManager.GetActiveScene().buildIndex==levelNum+3)
        {
            levelNum = SceneManager.GetActiveScene().buildIndex - 2;
            SavePlayer();
            levelPassed = false;
        }
        LoadPlayer();
    }

    public void NewLevelPassed()
    {
        levelPassed = true;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        levelNum = data.levelNumber;
    }
}