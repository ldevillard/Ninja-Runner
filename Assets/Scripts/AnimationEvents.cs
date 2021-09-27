using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    public void Quit(int idx)
    {
        SceneManager.UnloadSceneAsync(idx);
    }

    public void LoadSceneAdditive(int idx)
    {
        SceneManager.LoadSceneAsync(idx, LoadSceneMode.Additive);
    }

    public void LoadScene(int idx)
    {
        SceneManager.LoadSceneAsync(idx);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void GoDestroy()
    {
        Destroy(gameObject);
    }

    public void ResetAnim()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Taken", false);
    }

    public void ResetDeadAnim()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Dead", false);
    }

    public void ResetCoinAnim()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Coins", false);
    }

    public void SoundSwitch()
    {
        AudioFX.Mine.SFXSwitch();
    }

    public void SoundCoin()
    {
        AudioFX.Mine.SFXCoins();
    }

}
