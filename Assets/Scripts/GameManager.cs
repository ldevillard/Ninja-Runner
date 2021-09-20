using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;
    

    void Start()
    {
        Mine = this;
        GameStarted = false;
        Time.timeScale = 0.9f;

        SaveManager.Load("all");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
