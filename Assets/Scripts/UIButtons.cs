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
    public GameObject[] Buttons;

    float fpsCount;
    bool fpsDiplay;

    void Start()
    {
        TimeChanger.value = 0.9f;
        fpsDiplay = false;
    }

    public void StartButton()
    {
        StartingPoint.StartingGame = true;

        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(false);

        Destroy(ButtonStart);
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
