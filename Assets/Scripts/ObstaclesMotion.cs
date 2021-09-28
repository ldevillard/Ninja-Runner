using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesMotion : MonoBehaviour
{

    public float speed;
    public GameObject[] Moduls;

    void Awake()
    {
        if (PlayerPrefs.HasKey("tuto"))
            GenerateFirstTime();
        else
            GenerateTuto();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 120);
                RandomGenerator();
        }
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector3(transform.position.x, transform.position.y, Time.deltaTime * (-speed) + transform.position.z);
    }

    public void GenerateFirstTime()
    {
        int j = Random.Range(0, Moduls.Length);

        for (int i = 0; i < Moduls.Length; i++)
            Moduls[i].gameObject.SetActive(false);

        if (gameObject.name == "Pan1")
        {
            int k = Random.Range(0, 2);
            if (k == 0)
                Moduls[0].gameObject.SetActive(true);
            else
                Moduls[3].gameObject.SetActive(true);
        }
        else
            Moduls[j].gameObject.SetActive(true);
    }

    public void RandomGenerator()
    {
        int j = Random.Range(0, Moduls.Length);

        for (int i = 0; i < Moduls.Length; i++)
            Moduls[i].gameObject.SetActive(false);

        Moduls[j].gameObject.SetActive(true);

        var Enemy = Moduls[j].GetComponent<EnnemyGenerator>();
        if (Enemy != null && Score.ScorePoint > 10)
        {
            int k = Random.Range(0, 3);
            if (k == 0)
                Enemy.GenerateEnnemy();
        }

        Moduls[j].GetComponent<CoinsGenerator>().GenerateCoins();
    }

    void GenerateTuto()
    {
        if (Moduls[3].gameObject.activeSelf == true)
        {
            Moduls[3].GetComponent<EnnemyGenerator>().GenerateEnnemy();
        }
    }
}
