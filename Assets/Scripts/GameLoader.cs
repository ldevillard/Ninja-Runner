using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive); //Change when loader is active
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
