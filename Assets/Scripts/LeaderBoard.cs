using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    static public LeaderBoard Mine;

    public Animator anim;

    public GameObject rankPrefab;
    public GameObject yourRank;
    public Transform rankParent;

    public Text Name;
    public Text Scoretxt;

    public GameObject InternetTitle;

    void Start()
    {
        Mine = this;

        if (LeaderBoardManager.isLogged)
            LeaderBoardManager.Mine.SubmitName();

        AudioFX.Mine.SFXSettings();

        if (LeaderBoardManager.isLogged)
            LeaderBoardManager.Mine.GetLeaderBoard();
        else
            InternetTitle.SetActive(true);

        Name.text = LeaderBoardManager.Mine.UserName + "";
        Scoretxt.text = Score.HighScore + "";

        UIButtons.Mine.DisableUI();
    }

    public void QuitLeaderBoard()
    {
        UIButtons.Mine.ShowUI();
        AudioFX.Mine.SFXSettings();
        anim.SetBool("Quit", true);
    }
}
