using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float speed;
    public float timeOfLife;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (timeOfLife > 0)
            timeOfLife -= Time.deltaTime;
        else
            Destroy(gameObject);
    }

}
