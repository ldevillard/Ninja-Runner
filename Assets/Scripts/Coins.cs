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
            //GameObject FX = Instantiate(Effect, transform.parent);
            //FX.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            gameObject.SetActive(false);
        }
    }
}
