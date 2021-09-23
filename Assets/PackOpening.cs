using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOpening : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        AudioFX.Mine.SFXPackOpening();
    }

    public void Quit()
    {
        AudioFX.Mine.SFXSwitch();
        anim.SetBool("quit", true);
    }
}
