using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    static public Statistics Mine;

    public int NbrPartie;
    public int NbrEnemyKilled;
    public int NbrEnemyKilledDiscret;
    public int NbrFujiExplode;
    public int NbrCoinsCollected;
    public int NbrCoinsUsed;

    void Awake()
    {
        Mine = this;

        SaveManager.Load("stat");
    }

    void Update()
    {
       //Debug.Log(NbrPartie);    
    }
}
