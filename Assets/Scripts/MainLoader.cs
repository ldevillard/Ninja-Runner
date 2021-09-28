using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLoader : MonoBehaviour
{

    public Slider slider;
    public Text progressText;

    void Start()
    {
        LoadLevel(1);
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(Load(index));
        //StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator Load(int idx)
    {
        slider.value = 0;
        while (slider.value < 1)
        {
            slider.value += 0.02f;
            progressText.text = (int)(slider.value * 100) + "%";
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadSceneAsync(idx);
    }

    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
