using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    static public Settings Mine;

    public Animator anim;
    public Toggle ToggleFX;
    public Toggle ToggleMusic;
    public Slider VolumeHandlerMusic;
    public Slider VolumeHandlerSFX;

    void Start()
    {
        Mine = this;

        ToggleFX.isOn = AudioFX.Mine.SFX.enabled;
        ToggleMusic.isOn = AudioFX.Mine.MusicSource.enabled;
        VolumeHandlerMusic.value = AudioFX.Mine.MusicSource.volume;
        VolumeHandlerSFX.value = AudioFX.Mine.SFX.volume;

        AudioFX.Mine.SFXSettings();
    }

    public void QuitSettings()
    {
        AudioFX.Mine.SFXSettings();
        SaveManager.Save();
        anim.SetBool("Quit", true);
    }

    public void MusicToggle(bool newValue)
    {
        if (newValue)
            AudioFX.Mine.MusicSource.enabled = true;
        else
            AudioFX.Mine.MusicSource.enabled = false;
    }

    public void SFXToggle(bool newValue)
    {
        if (newValue)
        {
            AudioFX.Mine.SFX.enabled = true;
            AudioFX.Mine.RunSource.enabled = true;
        }
        else
        {
            AudioFX.Mine.SFX.enabled = false;
            AudioFX.Mine.RunSource.enabled = false;
        }
    }

    public void VolumeSliderMusic(float value)
    {
        AudioFX.Mine.MusicSource.volume = value;
    }

    public void VolumeSliderSFX(float value)
    {
        AudioFX.Mine.SFX.volume = value;
    }
}
