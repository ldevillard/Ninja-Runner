using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackOpening : MonoBehaviour
{
    public Animator anim;
    public Animator ChestAnim;
    public Animator ButtonPack;

    public GameObject PackedObjects;
    public GameObject PackButton;

    public GameObject NotEnoughMoney;

    public Text CoinsText;

    void Start()
    {
        AudioFX.Mine.SFXPackOpening();

        PackedObjects.SetActive(false);

        if (UnlockedChecker() == 1)
            PackButton.SetActive(false); //All item are unlock 
    }

    public void Quit()
    {
        AudioFX.Mine.SFXSwitch();
        anim.SetBool("quit", true);
    }

    public void OpenChest()
    {
        //Check Money
        if (Score.CoinPoint < 100)
        {
            NotEnoughMoney.SetActive(true);
            return;
        }
        else
        {
            Score.Mine.AddCoins(-100);
            Statistics.Mine.NbrCoinsUsed += 100;
            SaveManager.Save();
        }
        //Pack
        ChestAnim.SetBool("Open", true);
        ButtonPack.SetBool("Open", true);
        AudioFX.Mine.SFXOpenChest();

        PackedObjects.SetActive(true);
    }

    public int UnlockedChecker()
    {
        int i = 0;
        while (i < PlayerSkinManager.Mine.SkinUnlocked.Length)
        {
            if (!PlayerSkinManager.Mine.SkinUnlocked[i])
                return (0);
            i++;
        }

        i = 0;
        while (i < PlayerSkinManager.Mine.WeaponUnlocked.Length)
        {
            if (!PlayerSkinManager.Mine.WeaponUnlocked[i])
                return (0);
            i++;
        }
        return (1);
    }

    void Update()
    {
        CoinsText.text = "" + Score.CoinPoint;
    }
}
