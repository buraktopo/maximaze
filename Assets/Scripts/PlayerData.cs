using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int levelNumber;

    public PlayerData(Player player)
    {
        levelNumber = player.levelNum;
    }

    public PlayerData() {
        levelNumber = 1;
    }
}
