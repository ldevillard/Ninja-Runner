using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Animator anim;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "MainCamera")
            Destroy(gameObject);
        if (collision.collider.tag == "Weapon")
        {
            anim.SetBool("Killed", true);
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
