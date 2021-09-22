using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Shop : MonoBehaviour
{
    public GameObject[] Skins;
    public int idx;

    void Start()
    {
        for (int i = 0; i < Skins.Length; i++)
            Skins[i].SetActive(false);
        Skins[idx].SetActive(true);
    }
}
