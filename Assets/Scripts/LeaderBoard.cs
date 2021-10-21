using System.Collections;
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
    public GameObject LoadingTitle;

    void Start()
    {
        Mine = this;

        AudioFX.Mine.SFXSettings();

        if (LeaderBoardManager.isLogged)
        {
            LoadingTitle.SetActive(true);
            StartCoroutine(Loader());
        }
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

    IEnumerator Loader()
    {
        yield return new WaitForSeconds(0.25f);
        LeaderBoardManager.Mine.GetLeaderBoard();
    }
}
