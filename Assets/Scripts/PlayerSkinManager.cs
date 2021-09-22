using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    static public PlayerSkinManager Mine;

    public int idx;
    public GameObject[] Skins;
    public GameObject[] SkinsWeapon;

    void Start()
    {
        Mine = this;

        ResetSkin();
    }

    public void ResetSkin()
    {
        for (int i = 0; i < Skins.Length; i++)
            Skins[i].SetActive(false);
        Skins[idx].SetActive(true);
    }
}
