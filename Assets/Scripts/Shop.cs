using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Animator anim;
    public GameObject Panel;

    public Text DebugIDX;

    void Start()
    {
        AudioFX.Mine.SFXShop();    
    }

    public void QuitShop()
    {
        anim.SetBool("Quit", true);
        AudioFX.Mine.SFXShop();
        Panel.gameObject.SetActive(false);
    }

    void Update()
    { 
        DebugIDX.text = "" + Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().CurrentPanel;
    }
}
