using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    public void QuitShop()
    {
        SceneManager.UnloadSceneAsync(3);
    }
}
