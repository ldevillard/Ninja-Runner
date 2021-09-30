using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    static public UIButtons Mine;

    public Animator StartButton_Animator;
    public Slider TimeChanger;
    public Text FPS;
    public Text ScoreText;

    public Button Settings;

    public GameObject ButtonStart;
    public GameObject[] Buttons;

    public GameObject CanvasObject;
    public Text CoinsText;
    public Animator CoinsAnim;

    public Text CoinsText2;

    float fpsCount;
    bool fpsDiplay;

    void Start()
    {
        Mine = this;

        TimeChanger.value = 0.9f;
        fpsDiplay = false;
        CanvasObject.SetActive(false);

        if (!PlayerPrefs.HasKey("name"))
            DisableUI();

        if (Ads.NoAds)
            Buttons[9].SetActive(false); //Ads Button

        if (StartingPoint.StartingGame)
            DisableUI();
    }

    public void DisableUI()
    {
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(false);
    }

    public void ShowUI()
    {
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(true);

        if (Ads.NoAds)
            Buttons[9].SetActive(false); //Ads Button
    }

    public void StartButton()
    {
        StartingPoint.StartingGame = true;

        Statistics.Mine.NbrPartie++;
        SaveManager.Save();

        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(false);

        Destroy(ButtonStart);
    }

    public void OpenSceneAdditive(int idx)
    {
        SceneManager.LoadSceneAsync(idx, LoadSceneMode.Additive);
    }

    void Update()
    {
        //Time.timeScale = TimeChanger.value;
        if (!fpsDiplay)
            StartCoroutine(DisplayFPS());

        if (GameManager.Mine.GameStarted)
        {
            ScoreText.gameObject.SetActive(true);
            ScoreText.text = Score.ScorePoint + "";

            CanvasObject.SetActive(true);
            CoinsText.text = Score.CoinPoint + "";
        }
        else
            ScoreText.gameObject.SetActive(false);

        CoinsText2.text = Score.CoinPoint + "";
    }

    IEnumerator DisplayFPS()
    {
        fpsDiplay = true;
        yield return new WaitForSeconds(0.5f);
        fpsCount = (int)(1f / Time.unscaledDeltaTime);
        FPS.text = fpsCount + "FPS";
        fpsDiplay = false;
    }

    public void animCoin()
    {
        CoinsAnim.SetBool("Coins", true);
    }

    public void OpenGames()
    {
        Application.OpenURL("https://linktr.ee/LoganDev");
    }
}
