using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            AudioFX.Mine.SFXCoins();
            gameObject.SetActive(false);
            //Debug.Log("Coins");
        }
    }
}
