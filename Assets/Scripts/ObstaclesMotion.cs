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
        GenerateFirstTime();
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

        Moduls[j].gameObject.SetActive(true);
    }

    public void RandomGenerator()
    {
        int j = Random.Range(0, Moduls.Length);

        for (int i = 0; i < Moduls.Length; i++)
            Moduls[i].gameObject.SetActive(false);

        Moduls[j].gameObject.SetActive(true);

        var Enemy = Moduls[j].GetComponent<EnnemyGenerator>();
        if (Enemy != null && Score.Mine.ScorePoint > 10)
        {
            int k = Random.Range(0, 3);
            if (k == 0)
                Enemy.GenerateEnnemy();
        }

        Moduls[j].GetComponent<CoinsGenerator>().GenerateCoins();
    }
}
