using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingObject : MonoBehaviour
{
    public GameObject[] Objects;


    void Start()
    {
        GameObject[] tab;

        for (int i = 0; i < Objects.Length; i++)
            Objects[i].SetActive(false);

        int j = Random.Range(0, Objects.Length);

        if (CheckUnlockSkin() == 1)
            j = 1;
        else if (CheckUnlockWep() == 1)
            j = 0;

        Objects[j].SetActive(true);
        if (Objects[j].GetComponent<Character_Shop>() != null)
        {
            tab = Objects[j].GetComponent<Character_Shop>().Skins;
            for (int i = 0; i < tab.Length; i++)
                tab[i].SetActive(false);
            
            int k = Random.Range(0, tab.Length);

            while (PlayerSkinManager.Mine.SkinUnlocked[k])
                k = Random.Range(0, tab.Length);

            tab[k].SetActive(true);

            PlayerSkinManager.Mine.SkinUnlocked[k] = true;

            SaveManager.Save();
        }
        else if (Objects[j].GetComponent<Weapon_Shop>() != null)
        {
            tab = Objects[j].GetComponent<Weapon_Shop>().Skins;
            for (int i = 0; i < tab.Length; i++)
                tab[i].SetActive(false);

            int k = Random.Range(0, tab.Length);

            while (PlayerSkinManager.Mine.WeaponUnlocked[k])
                k = Random.Range(0, tab.Length);
            tab[k].SetActive(true);

            PlayerSkinManager.Mine.WeaponUnlocked[k] = true;

            SaveManager.Save();
        }
    }

    public int CheckUnlockSkin()
    {
        int i = 0;
        while (i < PlayerSkinManager.Mine.SkinUnlocked.Length)
        {
            if (!PlayerSkinManager.Mine.SkinUnlocked[i])
                return (0);
            i++;
        }
        return (1);
    }

    public int CheckUnlockWep()
    {
        int i = 0;
        while (i < PlayerSkinManager.Mine.WeaponUnlocked.Length)
        {
            if (!PlayerSkinManager.Mine.WeaponUnlocked[i])
                return (0);
            i++;
        }
        return (1);
    }
}
