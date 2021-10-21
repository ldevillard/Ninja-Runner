using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public Text ScoreTxt, HighscoreTxt;
    public GameObject AdButton;

    public GameObject Fade;

    public Image VideoIcon;
    public Sprite Heart;

    void Start()
    {

        AudioFX.Mine.SFXGameOver();
        SaveManager.Save();

        ScoreTxt.text = "" + Score.ScorePoint;
        HighscoreTxt.text = "" + Score.HighScore;

        if (PlayerPrefs.HasKey("score"))
        {
            AdButton.SetActive(false);
            PlayerPrefs.DeleteKey("score");
        }
        if (!PlayerPrefs.HasKey("tuto"))
            AdButton.SetActive(false);

        if (LeaderBoardManager.isLogged)
            LeaderBoardManager.Mine.SendLeaderBoard(Score.HighScore);

#if UNITY_ANDROID
        PlayGames.Mine.AddScoreToLeaderboard(Score.HighScore);
        if (Score.HighScore >= 100)
            PlayGames.Mine.UnlockAchievement();
#endif

        if (Ads.NoAds)
            VideoIcon.sprite = Heart;
    }

    public void RestartGame()
    {
        if (!Ads.NoAds)
            Ads.Mine.IncGameCounter();
        Fade.SetActive(true);
    }

    public void ShowRewardedAds()
    {
        if (!Ads.NoAds)
            Ads.Mine.ShowRewardedVideo();
        else
        {
            PlayerPrefs.SetInt("res", 1);
            PlayerPrefs.SetInt("score", Score.ScorePoint);
            PlayerPrefs.SetFloat("time", Time.timeScale);
            Fade.SetActive(true);
            //SceneManager.LoadSceneAsync(1);
        }
    }
}
