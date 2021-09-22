using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    static public Shop Mine;

    public Animator anim;
    public GameObject Panel;

    public Text DebugIDX;
    public GameObject ChooseButton;
    public GameObject SelectedAnim;

    void Start()
    {
        Mine = this;

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
        DebugIDX.text = "" + Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;

        if (getIdx() == PlayerSkinManager.Mine.idx)
            ChooseButton.SetActive(false);
        else
            ChooseButton.SetActive(true);
    }

    public void ChooseSkin()
    {
        GameObject select = Instantiate(SelectedAnim, ChooseButton.transform.parent);
        select.transform.position = new Vector3(ChooseButton.transform.position.x, ChooseButton.transform.position.y + 0.2f, ChooseButton.transform.position.z);
        PlayerSkinManager.Mine.idx = getIdx();
        PlayerSkinManager.Mine.ResetSkin();
    }

    public int getIdx()
    {
        return Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;
    }
}
