using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FujiExplode : MonoBehaviour
{

    public GameObject Particle, Sakura, SakuraRed;
    public CameraShake shake;
    public Material mat;
    public Material mat2;

    bool sky;
    bool skyChooser;

    int counter;

    void Start()
    {
        sky = false;
        skyChooser = false;
        Particle.SetActive(false);
        shake.enabled = false;
        Sakura.SetActive(true);
        SakuraRed.SetActive(false);
        counter = 0;
    }

    void Update()
    {
        if (Score.ScorePoint - counter > 500)
        {
            sky = true;
            skyChooser = !skyChooser;
            shake.enabled = true;
            shake.shakeDuration = 5;
            Particle.SetActive(true);
            Sakura.SetActive(false);
            SakuraRed.SetActive(true);
            AudioFX.Mine.SFXVolcano();
            counter = Score.ScorePoint;
        }
        if (sky)
        {
            if (skyChooser)
                RenderSettings.skybox.Lerp(RenderSettings.skybox, mat, 2 * Time.deltaTime);
            else
                RenderSettings.skybox.Lerp(RenderSettings.skybox, mat2, 2 * Time.deltaTime);
        }
    }
}
