using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;
    public Material mat;
    public Material[] Skyboxs;


    void Start()
    {
        Mine = this;
        GameStarted = false;
        Time.timeScale = 0.9f;

        RenderSettings.skybox = mat;
        GenerateSkybox();
        SaveManager.Load("all");
    }

    void GenerateSkybox()
    {
        int i = Random.Range(0, Skyboxs.Length);
        RenderSettings.skybox = Skyboxs[i];
        //Debug.Log(i);
    }
}
