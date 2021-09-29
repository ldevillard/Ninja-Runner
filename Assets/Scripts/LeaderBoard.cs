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

    void Start()
    {
        Mine = this;

        LeaderBoardManager.Mine.SubmitName();

        AudioFX.Mine.SFXSettings();
        LeaderBoardManager.Mine.GetLeaderBoard();
        Name.text = LeaderBoardManager.Mine.UserName + "";

        UIButtons.Mine.DisableUI();
    }

    public void QuitLeaderBoard()
    {
        UIButtons.Mine.ShowUI();
        AudioFX.Mine.SFXSettings();
        anim.SetBool("Quit", true);
    }
}