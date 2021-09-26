﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int highScore = 0;

    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if(_instance == null)
                {
                    Debug.LogError("Fatal Error : ScoreManager not Found");
                }
            }
            return _instance;
        }
    }

    #endregion

    public int tileRatio;
    public int comboRatio;

    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void IncrementCurrenttScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);
        SoundManager.Instance.PlayScore(comboCount > 1);
    }

    public void SetHighScore()
    {
        if(currentScore > ScoreData.highScore)
        {
            ScoreData.highScore = currentScore;
        }
    }
}