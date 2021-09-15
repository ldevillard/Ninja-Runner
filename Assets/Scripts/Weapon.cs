using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float speed;
    public float timeOfLife;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ennemy")
            Destroy(gameObject);
    }

        void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (timeOfLife > 0)
            timeOfLife -= Time.deltaTime;
        else
            Destroy(gameObject);
    }

}
