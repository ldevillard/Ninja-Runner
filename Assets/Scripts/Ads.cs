using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour, IUnityAdsListener
{
    static public Ads Mine;

    bool testMode = false;
    string mySurfacingId = "rewardedVideo";

    static public bool NoAds;
    public int nbrGame;

    bool reward;

#if UNITY_IOS
    private string gameId = "4380132";
#elif UNITY_ANDROID
    private string gameId = "4380133";
#endif

    void Awake()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    void Start()
    {
        Mine = this;

        NoAds = false;
        SaveManager.Load("ads");

        if (PlayerPrefs.HasKey("counterAds"))
            nbrGame = PlayerPrefs.GetInt("counterAds");
        else
            nbrGame = 0;

        reward = false;
    }

    public void IncGameCounter()
    {
        nbrGame++;
        if (nbrGame == 3)
        {
            nbrGame = 0;
            ShowAd();
        }
        Debug.Log(nbrGame);
        PlayerPrefs.SetInt("counterAds", nbrGame);
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady("Inter"))
        {
            Advertisement.Show("Inter");
            if (AudioFX.Mine.MusicSource.enabled)
                AudioFX.Mine.MusicSource.mute = true;
        }
        else
            Debug.Log("Ad can't be shown at the moment!");
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            reward = true;
            if (AudioFX.Mine.MusicSource.enabled)
                AudioFX.Mine.MusicSource.mute = true;
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (reward)
            {
                PlayerPrefs.SetInt("res", 1);
                PlayerPrefs.SetInt("score", Score.ScorePoint);
                PlayerPrefs.SetFloat("time", Time.timeScale);
                SceneManager.LoadSceneAsync(1);
            
                reward = false;
            }
            if (AudioFX.Mine.MusicSource.enabled)
                AudioFX.Mine.MusicSource.mute = false;
        }
        else if (showResult == ShowResult.Skipped)
        {
            if (AudioFX.Mine.MusicSource.enabled)
                AudioFX.Mine.MusicSource.mute = false;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
            if (AudioFX.Mine.MusicSource.enabled)
                AudioFX.Mine.MusicSource.mute = false;
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
