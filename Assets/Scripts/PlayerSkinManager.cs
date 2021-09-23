using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    static public PlayerSkinManager Mine;

    public int idx;
    public int idxWep;
    public GameObject[] Skins;
    public GameObject[] SkinsWeapon;

    public bool[] SkinUnlocked;
    public bool[] WeaponUnlocked;

    void Start()
    {
        Mine = this;

        SaveManager.Load("all");
        ResetSkin();
        ResetWep();
    }

    public void ResetSkin()
    {
        for (int i = 0; i < Skins.Length; i++)
            Skins[i].SetActive(false);
        Skins[idx].SetActive(true);
    }

    public void ResetWep()
    {
        PlayerController.Weapon = SkinsWeapon[idxWep];
    }
}
