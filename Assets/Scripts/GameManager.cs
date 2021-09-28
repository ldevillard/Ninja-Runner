using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            File.Delete(Application.persistentDataPath + "/save.bipbop");
            PlayerPrefs.DeleteAll();
            Debug.Log("Save deleted");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Score.Mine.AddCoins(100);
            SaveManager.Save();
            Debug.Log("Add 100 coins");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("tuto", 1);
            Debug.Log("set tuto");
        }
    }
}
