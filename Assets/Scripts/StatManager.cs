using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Animator anim;
    public Text Partyplayed;
    public Text EnemyKilled;
    public Text EnemyKilledDiscret;
    public Text FujiExplode;
    public Text CoinsCollected;
    public Text CoinsUsed;

    void Start()
    {
        AudioFX.Mine.SFXSettings();

        Partyplayed.text = "" + Statistics.Mine.NbrPartie;
        EnemyKilled.text = "" + Statistics.Mine.NbrEnemyKilled;
        EnemyKilledDiscret.text = "" + Statistics.Mine.NbrEnemyKilledDiscret;
        FujiExplode.text = "" + Statistics.Mine.NbrFujiExplode;
        CoinsCollected.text = "" + Statistics.Mine.NbrCoinsCollected;
        CoinsUsed.text = "" + Statistics.Mine.NbrCoinsUsed;

    }

    public void Quit()
    {
        anim.SetBool("Quit", true);
        AudioFX.Mine.SFXSettings();
    }
}
