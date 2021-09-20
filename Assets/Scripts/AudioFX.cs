using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    static public AudioFX Mine;

    public AudioClip Switch, Switch2, Jump, Attack, Spoted, Scream, OpenSettings;
    public AudioSource SFX;
    public AudioSource MusicSource;

    void Awake()
    {
        Mine = this;
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

}
