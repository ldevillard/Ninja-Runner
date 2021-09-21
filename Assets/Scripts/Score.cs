using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score Mine;

    static public int ScorePoint;
    static public int CoinPoint;

    int scoreCalculator;
    float counter;

    void Start()
    {
        Mine = this;
        counter = 0;
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
    }

    public void AddCoins(int quantity)
    {
        CoinPoint += quantity;
        UIButtons.Mine.animCoin();
        SaveManager.Save();
    }
}
