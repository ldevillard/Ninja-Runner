using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    static public AudioFX Mine;

    public AudioClip Switch, Switch2, Jump, Attack, Spoted, Scream, OpenSettings, Run, Volcano, DiscreteKill, Shop, ShopSelect, PackOpening, OpenChest, GameOver;
    public AudioClip[] Coins;
    public AudioSource SFX;

    public AudioClip[] Musics;

    public AudioSource MusicSource;
    public AudioSource RunSource;

    public int indexSaver;
    
    void Awake()
    {
        Mine = this;
        RunSource.volume = 0;

        indexSaver = -1;
    }

    void GenerateMusic()
    {
        int i;

        while ((i = Random.Range(0, Musics.Length)) == indexSaver)
            ;

        indexSaver = i;

        MusicSource.PlayOneShot(Musics[i]);
    }

    void FixedUpdate()
    {
        if (!RunSource.isPlaying)
            RunSource.PlayOneShot(Run);

        if (!MusicSource.isPlaying && MusicSource.enabled)
            GenerateMusic();
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

    public void SFXPackOpening()
    {
        SFX.PlayOneShot(PackOpening);
    }

    public void SFXOpenChest()
    {
        SFX.PlayOneShot(OpenChest);
    }

    public void SFXGameOver()
    {
        SFX.PlayOneShot(GameOver);
    }
}
