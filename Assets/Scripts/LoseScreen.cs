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
    }

    public void RestartGame()
    {
        Fade.SetActive(true);
    }

    public void ShowRewardedAds()
    {
        Ads.Mine.ShowRewardedVideo();
    }
}
