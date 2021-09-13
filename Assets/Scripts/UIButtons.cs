using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public Animator StartButton_Animator;
    public Slider TimeChanger;
    public Text FPS;

    float fpsCount;
    bool fpsDiplay;

    void Start()
    {
        TimeChanger.value = 0.9f;
        fpsDiplay = false;
    }

    public void StartButton()
    {
        StartButton_Animator.SetBool("GameStarted", true);
        GameManager.Mine.GameStarted = true;
        //Debug.Log("Start");
    }

    void Update()
    {
        Time.timeScale = TimeChanger.value;
        if (!fpsDiplay)
            StartCoroutine(DisplayFPS());
    }

    IEnumerator DisplayFPS()
    {
        fpsDiplay = true;
        yield return new WaitForSeconds(0.5f);
        fpsCount = (int)(1f / Time.unscaledDeltaTime);
        FPS.text = fpsCount + "FPS";
        fpsDiplay = false;
    }
}
