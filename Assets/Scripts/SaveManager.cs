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

        saver.MusicVol = AudioFX.Mine.MusicSource.volume;
        saver.SFXVol = AudioFX.Mine.SFX.volume;
        saver.MusicIsOn = AudioFX.Mine.MusicSource.enabled;
        saver.SFXIsOn = AudioFX.Mine.SFX.enabled;
        saver.Coins = Score.CoinPoint;

        Binary.Serialize(Fstream, saver);
        Fstream.Close();

        Debug.Log("Successful to save!");
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

            Debug.Log("Successful to load!");
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
    }
} 