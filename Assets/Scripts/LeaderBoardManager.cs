using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    static public LeaderBoardManager Mine;

    public string UserName;

    static public bool isLogged;

    void Start()
    {
        Mine = this;

        isLogged = false;

        Login();
    }

    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void SubmitName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = UserName,
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Successful to update user name!");
    }

    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Highscore",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Highscore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        isLogged = true;
        Debug.Log("Successful login/account create!");
        string name = null;

        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
    }

    void OnError(PlayFabError error)
    {
        isLogged = false;
        Debug.Log("Error while login/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }


    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard send!");
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            if (item.StatValue > 0)
            {
                GameObject newRank = Instantiate(LeaderBoard.Mine.rankPrefab, LeaderBoard.Mine.rankParent);
                Text[] texts = newRank.GetComponentsInChildren<Text>();
                texts[0].text = (item.Position + 1).ToString();
                texts[1].text = item.DisplayName;
                texts[2].text = item.StatValue.ToString();
            }
            if (Score.HighScore == 0)
            {
                Text[] yourTexts = LeaderBoard.Mine.yourRank.GetComponentsInChildren<Text>();
                yourTexts[0].text = "-";
                yourTexts[1].text = UserName;
                yourTexts[2].text = "0";
            }
            else if (item.StatValue == Score.HighScore)
            {
                Text[] yourTexts = LeaderBoard.Mine.yourRank.GetComponentsInChildren<Text>();
                yourTexts[0].text = (item.Position + 1).ToString();
                yourTexts[1].text = item.DisplayName;
                yourTexts[2].text = item.StatValue.ToString();
            }

            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }
}
