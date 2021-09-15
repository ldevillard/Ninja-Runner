using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Skins;

    void Start()
    {
        for (int i = 0; i < Skins.Length; i++)
            Skins[i].SetActive(false);
        int j = Random.Range(0, Skins.Length);
        Skins[j].SetActive(true);

        int k = Random.Range(0, 2);
        switch (k)
        {
            case 0:
                anim.SetBool("Idle", true);
                break;
            case 1:
                anim.SetBool("Back", true);
                break;
        }
    }

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
