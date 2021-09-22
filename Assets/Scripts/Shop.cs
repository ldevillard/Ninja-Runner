using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    static public Shop Mine;

    public Animator anim;
    public GameObject Panel;
    public GameObject Panel2;

    public Text DebugIDX;
    public GameObject ChooseButton;
    public GameObject ChooseWeapon;
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
        Panel2.gameObject.SetActive(false);
    }

    void Update()
    { 
        DebugIDX.text = "" + Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;

        if (getIdx() == PlayerSkinManager.Mine.idx)
            ChooseButton.SetActive(false);
        else
            ChooseButton.SetActive(true);

        if (getIdxWeapon() == PlayerSkinManager.Mine.idxWep)
            ChooseWeapon.SetActive(false);
        else
            ChooseWeapon.SetActive(true);
    }

    public void ChooseSkin()
    {
        AudioFX.Mine.SFXShopSelect();
        GameObject select = Instantiate(SelectedAnim, ChooseButton.transform.parent);
        select.transform.position = new Vector3(ChooseButton.transform.position.x, ChooseButton.transform.position.y + 0.25f, ChooseButton.transform.position.z);
        PlayerSkinManager.Mine.idx = getIdx();
        PlayerSkinManager.Mine.ResetSkin();
    }

    public void ChooseWeaponSkin()
    {
        AudioFX.Mine.SFXShopSelect();
        GameObject select = Instantiate(SelectedAnim, ChooseWeapon.transform.parent);
        select.transform.position = new Vector3(ChooseWeapon.transform.position.x, ChooseWeapon.transform.position.y + 0.25f, ChooseWeapon.transform.position.z);
        PlayerSkinManager.Mine.idxWep = getIdxWeapon();
        PlayerSkinManager.Mine.ResetWep();
    }

    public int getIdx()
    {
        return Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;
    }

    public int getIdxWeapon()
    {
        return Panel2.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;
    }
}
