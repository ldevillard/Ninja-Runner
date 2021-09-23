using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public int idxCharacter;
    public int idxWeapon;
    public bool[] SkinsUnlocked;
    public bool[] WeaponsUnlocked;

    void Start()
    {
        Mine = this;

        AudioFX.Mine.SFXShop();

        idxCharacter = PlayerSkinManager.Mine.idx;
        idxWeapon = PlayerSkinManager.Mine.idxWep;
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
        else if (SkinsUnlocked[getIdx()])  //If the skin is unlocked
            ChooseButton.SetActive(true);
        else
            ChooseButton.SetActive(false);

        if (getIdxWeapon() == PlayerSkinManager.Mine.idxWep)
            ChooseWeapon.SetActive(false);
        else if (WeaponsUnlocked[getIdxWeapon()])
            ChooseWeapon.SetActive(true);
        else
            ChooseWeapon.SetActive(false);
    }

    public void ChooseSkin()
    {
        AudioFX.Mine.SFXShopSelect();
        GameObject select = Instantiate(SelectedAnim, ChooseButton.transform.parent);
        select.transform.position = new Vector3(ChooseButton.transform.position.x, ChooseButton.transform.position.y, ChooseButton.transform.position.z);

        idxCharacter = getIdx();
        PlayerSkinManager.Mine.idx = getIdx();
        PlayerSkinManager.Mine.ResetSkin();

        SaveManager.Save();
    }

    public void ChooseWeaponSkin()
    {
        AudioFX.Mine.SFXShopSelect();
        GameObject select = Instantiate(SelectedAnim, ChooseWeapon.transform.parent);
        select.transform.position = new Vector3(ChooseWeapon.transform.position.x, ChooseWeapon.transform.position.y, ChooseWeapon.transform.position.z);

        idxWeapon = getIdxWeapon();
        PlayerSkinManager.Mine.idxWep = getIdxWeapon();
        PlayerSkinManager.Mine.ResetWep();

        SaveManager.Save();
    }

    public int getIdx()
    {
        return Panel.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;
    }

    public int getIdxWeapon()
    {
        return Panel2.GetComponent<DanielLochner.Assets.SimpleScrollSnap.SimpleScrollSnap>().TargetPanel;
    }

    public void OpenPackOpening()
    {
        SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
    }
}
