using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject Effect;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            AudioFX.Mine.SFXCoins();
            PlayerController.Mine.GenerateCoinFX();
            Score.Mine.AddCoins(1);

            gameObject.SetActive(false);
        }
    }
}
