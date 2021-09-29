using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.HasKey("tuto"))
        {
            gameObject.SetActive(false);
        }
    }
}
