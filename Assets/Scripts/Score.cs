using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score Mine;

    static public int ScorePoint;
    static public int HighScore;
    static public int CoinPoint;

    int scoreCalculator;
    float counter;

    void Start()
    {
        Mine = this;
        counter = 0;
        if (PlayerPrefs.HasKey("score"))
        {
            ScorePoint = PlayerPrefs.GetInt("score");
            InitTimeScale();
        }
        else
            ScorePoint = 0;
        scoreCalculator = ScorePoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Mine.GameStarted)
        {
            counter += Time.deltaTime * Time.timeScale;
            if (counter > 0.1)
            {
                ScorePoint++;
                counter = 0;
            }
            if (ScorePoint - 150 > scoreCalculator && Time.timeScale < 1.8f)
            {
                scoreCalculator += 150;
                Time.timeScale += 0.1f;
            }
        }

        if (ScorePoint > HighScore)
            HighScore = ScorePoint;
        //Debug.Log(Time.timeScale);
    }

    void InitTimeScale()
    {
        int buf = ScorePoint / 150;
        while (buf > 0 && Time.timeScale < 1.8f)
        {
            Time.timeScale += 0.1f;
            buf--;
        }
    }

    public void AddCoins(int quantity)
    {
        CoinPoint += quantity;
        UIButtons.Mine.animCoin();

        if (quantity > 0)
            Statistics.Mine.NbrCoinsCollected += quantity;
        SaveManager.Save();

        //SaveManager.Save();
    }
}
