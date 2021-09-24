using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    static public Statistics Mine;

    public int NbrPartie;
    public int NbrEnemyKilled;

    void Start()
    {
        Mine = this;

        SaveManager.Load("stat");
    }

    void Update()
    {
       //Debug.Log(NbrPartie);    
    }
}
