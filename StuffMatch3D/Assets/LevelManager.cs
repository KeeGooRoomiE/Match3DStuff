using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameController game;
    [SerializeField] public int levelNumber;
    [SerializeField] public LevelSet[] levelSet;

    public void SetLevelNumber(int number)
    {
        levelNumber = number;
    }

    public void IncreaseLevelNumber()
    {
        levelNumber += 1;
    }

    public void SetLevel(int number)
    {
        game.pairGenNumber = levelSet[number].PairNumber;
        game.isTutorial = levelSet[number].isTutorial;
        game.isTimerOn = levelSet[number].timerActive;
        game.isBooster1On = levelSet[number].booster1Active;
        game.isBooster2On = levelSet[number].booster2Active;
        game.levelTime = levelSet[number].LevelTime;
        game.noNeedToGen = false;

        if (number == 1)
        {
            game.isTutorial = true;
            game.isTimerOn = false;
            game.isBooster1On = false;
            game.isBooster2On = false;
            game.levelTime = 999999;
            game.pairGenNumber = 3;
            game.noNeedToGen = true;
        }
    }

    public void SetLevelAuto()
    {
        game.pairGenNumber = levelSet[levelNumber].PairNumber;
        game.isTutorial = levelSet[levelNumber].isTutorial;
        game.isTimerOn = levelSet[levelNumber].timerActive;
        game.isBooster1On = levelSet[levelNumber].booster1Active;
        game.isBooster2On = levelSet[levelNumber].booster2Active;
        game.levelTime = levelSet[levelNumber].LevelTime;

        if (levelNumber == 1)
        {
            game.isTutorial = true;
            game.isTimerOn = false;
            game.isBooster1On = false;
            game.isBooster2On = false;
            game.levelTime = 999999;
            game.pairGenNumber = 3;
            game.noNeedToGen = true;
        }
    }
}

[Serializable]
public class LevelSet
{
    public bool isTutorial = false;
    public bool timerActive = true;
    public bool booster1Active = true;
    public bool booster2Active = true;
    public int LevelNumber = 0;
    public int LevelTime = 0;
    public int PairNumber = 0;
    
}
