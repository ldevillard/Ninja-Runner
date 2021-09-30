using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPShop : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        AudioFX.Mine.SFXShop();
    }

    public void OnQuit()
    {
        AudioFX.Mine.SFXShop();
        anim.SetBool("Quit", true);
    }
}
