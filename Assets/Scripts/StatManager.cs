using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Animator anim;
    public Text Partyplayed;

    void Start()
    {
        AudioFX.Mine.SFXSettings();

        Partyplayed.text = "" + Statistics.Mine.NbrPartie;
    }

    public void Quit()
    {
        anim.SetBool("Quit", true);
        AudioFX.Mine.SFXSettings();
    }
}
