using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLantern : MonoBehaviour
{

    private Light lux;
    bool isFlashing;
    float speed = 0.01f;

    void Start()
    {
        lux = GetComponent<Light>();
        lux.intensity = 8;
        isFlashing = false;
    }

    void Update()
    {
        if (!isFlashing)
            StartCoroutine(toFlash());
    }

    IEnumerator toFlash()
    {
        isFlashing = true;
        while (lux.intensity < 20)
        {
            lux.intensity++;
            yield return new WaitForSeconds(speed);
        }

        while (lux.intensity > 8)
        {
            lux.intensity--;
            yield return new WaitForSeconds(speed);
        }
        isFlashing = false;
    }
}
