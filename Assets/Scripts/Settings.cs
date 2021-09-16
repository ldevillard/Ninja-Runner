using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Animator anim;
    public Toggle ToggleFX;
    public Toggle ToggleMusic;
    public Slider VolumeHandler;

    void Start()
    {
        ToggleFX.isOn = AudioFX.Mine.SFX.enabled;
        ToggleMusic.isOn = AudioFX.Mine.MusicSource.enabled;
        VolumeHandler.value = AudioFX.Mine.MusicSource.volume;
    }

    public void QuitSettings()
    {
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
            AudioFX.Mine.SFX.enabled = true;
        else
            AudioFX.Mine.SFX.enabled = false;
    }

    public void VolumeSlider(float value)
    {
        AudioFX.Mine.MusicSource.volume = value;
        AudioFX.Mine.SFX.volume = value;
    }
}
