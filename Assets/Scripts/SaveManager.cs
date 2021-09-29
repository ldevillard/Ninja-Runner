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
        saver.HighScore = Score.HighScore;

        //SHOP
        saver.idxCharacter = PlayerSkinManager.Mine.idx;
        saver.idxWeapon = PlayerSkinManager.Mine.idxWep;

        saver.CharacterUnlocked = PlayerSkinManager.Mine.SkinUnlocked;
        saver.WeaponUnlocked = PlayerSkinManager.Mine.WeaponUnlocked;

        //STAT
        saver.NbrPartie = Statistics.Mine.NbrPartie;
        saver.NbrEnemyKilled = Statistics.Mine.NbrEnemyKilled;
        saver.NbrEnemyKilledDiscret = Statistics.Mine.NbrEnemyKilledDiscret;
        saver.NbrFujiExplode = Statistics.Mine.NbrFujiExplode;
        saver.NbrCoinsCollected = Statistics.Mine.NbrCoinsCollected;
        saver.NbrCoinsUsed = Statistics.Mine.NbrCoinsUsed;

        //DATABASE
        saver.UserName = LeaderBoardManager.Mine.UserName;

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
                Score.HighScore = saver.HighScore;
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
                Statistics.Mine.NbrPartie = saver.NbrPartie;
                Statistics.Mine.NbrEnemyKilled = saver.NbrEnemyKilled;
                Statistics.Mine.NbrEnemyKilledDiscret = saver.NbrEnemyKilledDiscret;
                Statistics.Mine.NbrFujiExplode = saver.NbrFujiExplode;
                Statistics.Mine.NbrCoinsCollected = saver.NbrCoinsCollected;
                Statistics.Mine.NbrCoinsUsed = saver.NbrCoinsUsed;
            }
            if (target == "name" || target == "all")
                LeaderBoardManager.Mine.UserName = saver.UserName;
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
        public int HighScore;

        //SHOP
        public int idxCharacter;
        public int idxWeapon;
        public bool[] CharacterUnlocked;
        public bool[] WeaponUnlocked;

        //STAT
        public int NbrPartie;
        public int NbrEnemyKilled;
        public int NbrEnemyKilledDiscret;
        public int NbrFujiExplode;
        public int NbrCoinsCollected;
        public int NbrCoinsUsed;

        //DATA BASE
        public string UserName;
    }
} 