using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    static public AudioFX Mine;

    public AudioClip Switch, Switch2, Jump, Attack;
    public AudioSource SFX;

    void Start()
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

}
