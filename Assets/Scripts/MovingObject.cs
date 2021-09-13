using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 120);
        }
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector3(transform.position.x, transform.position.y, Time.deltaTime * (-speed) + transform.position.z);
    }
}
