using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOpening : MonoBehaviour
{
    public Animator anim;
    public Animator ChestAnim;
    public Animator ButtonPack;

    public GameObject PackedObjects;

    void Start()
    {
        AudioFX.Mine.SFXPackOpening();

        PackedObjects.SetActive(false);
    }

    public void Quit()
    {
        AudioFX.Mine.SFXSwitch();
        anim.SetBool("quit", true);
    }

    public void OpenChest()
    {
        //Check Money

        ChestAnim.SetBool("Open", true);
        ButtonPack.SetBool("Open", true);
        AudioFX.Mine.SFXOpenChest();

        PackedObjects.SetActive(true);
    }
}
