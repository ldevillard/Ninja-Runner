using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score Mine;

    public int ScorePoint;
    float counter;

    void Start()
    {
        Mine = this;
        counter = 0;
        ScorePoint = 0;
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
        }
    }
}
