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

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void ResetAnim()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Taken", false);
    }

    public void ResetCoinAnim()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Coins", false);
    }

}
