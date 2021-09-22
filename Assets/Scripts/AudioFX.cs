using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    static public AudioFX Mine;

    public AudioClip Switch, Switch2, Jump, Attack, Spoted, Scream, OpenSettings, Run, Volcano, DiscreteKill, Shop, ShopSelect;
    public AudioClip[] Coins;
    public AudioSource SFX;
    public AudioSource MusicSource;
    public AudioSource RunSource;

    void Awake()
    {
        Mine = this;
        RunSource.volume = 0;
    }

    void FixedUpdate()
    {
        if (!RunSource.isPlaying)
            RunSource.PlayOneShot(Run);
    }

    public void SFXSwitch()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
            SFX.PlayOneShot(Switch);
        else
            SFX.PlayOneShot(Switch2);
    }

    public void SFXAttack()
    {
        SFX.PlayOneShot(Attack);
    }

    public void SFXJump()
    {
        SFX.PlayOneShot(Jump);
    }

    public void SFXSpoted()
    {
        SFX.PlayOneShot(Spoted);
    }

    public void SFXKilled()
    {
        SFX.PlayOneShot(Scream);
    }

    public void SFXSettings()
    {
        SFX.PlayOneShot(OpenSettings);
    }

    public void SFXVolcano()
    {
        SFX.PlayOneShot(Volcano);
    }

    public void SFXCoins()
    {
        int i = Random.Range(0, Coins.Length);
        SFX.PlayOneShot(Coins[i]);
    }

    public void SFXDiscreteKill()
    {
        SFX.PlayOneShot(DiscreteKill);
    }

    public void SFXShop()
    {
        SFX.PlayOneShot(Shop);
    }

    public void SFXShopSelect()
    {
        SFX.PlayOneShot(ShopSelect);
    }

}
