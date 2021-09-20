using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    static public CoinsGenerator Mine;

    public GameObject[] Coins;

    void Start()
    {
        Mine = this;    
    }

    public void GenerateCoins()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            for (int j = 0; j < Coins.Length; j++)
                Coins[j].SetActive(true);
        }
        else
        {
            for (int j = 0; j < Coins.Length; j++)
                Coins[j].SetActive(false);
        }
    }
}
