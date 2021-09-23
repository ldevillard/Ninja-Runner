using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingObject : MonoBehaviour
{
    public GameObject[] Objects;


    void Start()
    {
        int count = 0;
        GameObject[] tab;

        for (int i = 0; i < Objects.Length; i++)
            Objects[i].SetActive(false);

        int j = Random.Range(0, Objects.Length);

        Objects[j].SetActive(true);
        if (Objects[j].GetComponent<Character_Shop>() != null)
        {
            tab = Objects[j].GetComponent<Character_Shop>().Skins;
            for (int i = 0; i < tab.Length; i++)
                tab[i].SetActive(false);
            
            int k = Random.Range(0, tab.Length);

            while (PlayerSkinManager.Mine.SkinUnlocked[k])
            {
                k = Random.Range(0, tab.Length);
                count++;
                if (count > 20)
                    break;
            }

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
            {
                k = Random.Range(0, tab.Length);
                count++;
                if (count > 20)
                    break;
            }

            tab[k].SetActive(true);

            PlayerSkinManager.Mine.WeaponUnlocked[k] = true;

            SaveManager.Save();
        }
    }
}
