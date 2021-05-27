using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameController game;
    public int levelNumber;

    [SerializeField] public LevelSet[] levelSet;


    // Start is called before the first frame update
    public void SetLevel(int number)
    {
        game.pairGenNumber = levelSet[number].PairNumber;
    }

    public void SetLevelNumber(int number)
    {
        levelNumber = number;
    }
}

[Serializable]
public class LevelSet
{
    public bool isTutorial = false;
    public int LevelNumber = 0;
    public int LevelTime = 0;
    public int PairNumber = 0;
    
}
