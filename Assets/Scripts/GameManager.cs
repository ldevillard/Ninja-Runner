using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;
    
    public GameObject TestPrefab;

    void Start()
    {
        Mine = this;
        GameStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
