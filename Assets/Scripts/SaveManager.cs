using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{

    static public void Save()
    {
        BinaryFormatter Binary = new BinaryFormatter();
        FileStream Fstream = File.Create(Application.persistentDataPath + "/save.bipbop");
        Data saver = new Data();

        //SOUND
        saver.MusicVol = AudioFX.Mine.MusicSource.volume;
        saver.SFXVol = AudioFX.Mine.SFX.volume;
        saver.MusicIsOn = AudioFX.Mine.MusicSource.enabled;
        saver.SFXIsOn = AudioFX.Mine.SFX.enabled;

        //SCORE
        saver.Coins = Score.CoinPoint;

        //SHOP
        saver.idxCharacter = PlayerSkinManager.Mine.idx;
        saver.idxWeapon = PlayerSkinManager.Mine.idxWep;

        saver.CharacterUnlocked = PlayerSkinManager.Mine.SkinUnlocked;
        saver.WeaponUnlocked = PlayerSkinManager.Mine.WeaponUnlocked;

        //STAT
        Debug.Log("Je vais save : " + Statistics.Mine.NbrPartie);
        saver.NbrPartie = Statistics.Mine.NbrPartie;

        Binary.Serialize(Fstream, saver);
        Fstream.Close();

        //Debug.Log("Successful to save!");
    }

    static public void Load(string target)
    {
        if (File.Exists(Application.persistentDataPath + "/save.bipbop"))
        {
            BinaryFormatter Binary = new BinaryFormatter();
            FileStream Fstream = File.Open(Application.persistentDataPath + "/save.bipbop", FileMode.Open);
            Data saver = (Data)Binary.Deserialize(Fstream);
            Fstream.Close();

            if (target == "sound" || target == "all")
            {
                AudioFX.Mine.MusicSource.volume = saver.MusicVol;
                AudioFX.Mine.SFX.volume = saver.SFXVol;
                AudioFX.Mine.MusicSource.enabled = saver.MusicIsOn;
                AudioFX.Mine.SFX.enabled = saver.SFXIsOn;
                AudioFX.Mine.RunSource.enabled = saver.SFXIsOn;
            }
            if (target == "score" || target == "all")
            {
                Score.CoinPoint = saver.Coins;
            }
            if (target == "shop" || target == "all")
            {
                PlayerSkinManager.Mine.idx = saver.idxCharacter;
                PlayerSkinManager.Mine.idxWep = saver.idxWeapon;

            }
            if (target == "shopUnlock" || target == "all")
            {
                PlayerSkinManager.Mine.SkinUnlocked = saver.CharacterUnlocked;
                PlayerSkinManager.Mine.WeaponUnlocked = saver.WeaponUnlocked;
            }
            if (target == "stat" || target == "all")
            {
                Debug.Log("Je vais load : " + saver.NbrPartie);
                Statistics.Mine.NbrPartie = saver.NbrPartie;
            }

            //Debug.Log("Successful to load!");
        }
        else
            Debug.LogWarning("SaveFile not found!");
    }

    [Serializable]
    public class Data
    {
        //SOUND
        public float MusicVol;
        public float SFXVol;
        public bool MusicIsOn;
        public bool SFXIsOn;

        //SCORE
        public int Coins;

        //SHOP
        public int idxCharacter;
        public int idxWeapon;
        public bool[] CharacterUnlocked;
        public bool[] WeaponUnlocked;

        //STAT
        public int NbrPartie;
    }
} 