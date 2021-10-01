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

    public Text MusicText;
    public bool dis;

    void Start()
    {
        Mine = this;

        dis = false;
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
        dis = true;
    }

    public void ShowUI()
    {
        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(true);

        if (Ads.NoAds)
            Buttons[9].SetActive(false); //Ads Button

        dis = false;
    }

    public void StartButton()
    {
        StartingPoint.StartingGame = true;

        Statistics.Mine.NbrPartie++;
        SaveManager.Save();

        DisableUI();

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

        if (AudioFX.Mine.MusicSource.enabled && !dis)
        {
            MusicText.gameObject.SetActive(true);
            MusicText.text = "" + AudioFX.Mine.Musics[AudioFX.Mine.indexSaver].name;
        }
        else
            MusicText.gameObject.SetActive(false);
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
