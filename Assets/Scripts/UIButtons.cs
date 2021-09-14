using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public Animator StartButton_Animator;
    public Slider TimeChanger;
    public Text FPS;
    public Text ScoreText;

    public GameObject ButtonStart;

    float fpsCount;
    bool fpsDiplay;

    void Start()
    {
        TimeChanger.value = 0.9f;
        fpsDiplay = false;
    }

    public void StartButton()
    {
        //StartButton_Animator.SetBool("GameStarted", true);
        StartingPoint.StartingGame = true;
        Destroy(ButtonStart);
        //GameManager.Mine.GameStarted = true;
        //Debug.Log("Start");
    }

    void Update()
    {
        //Time.timeScale = TimeChanger.value;
        if (!fpsDiplay)
            StartCoroutine(DisplayFPS());

        if (GameManager.Mine.GameStarted)
        {
            ScoreText.gameObject.SetActive(true);
            ScoreText.text = Score.Mine.ScorePoint + "";
        }
        else
            ScoreText.gameObject.SetActive(false);
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
