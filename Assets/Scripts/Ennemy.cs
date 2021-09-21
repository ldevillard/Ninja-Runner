using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Skins;
    public GameObject Exclamation;

    public GameObject Effect;
    public GameObject DiscreteEffect;

    bool Spoted;
    bool isAlive;

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

        Spoted = false;
        isAlive = true;
    }

    void Update()
    {
        RayCast();    
    }

    void RayCast()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Debug.DrawRay(pos, Vector3.back * 5, Color.cyan); //Draw a debug cast
        Ray ray = new Ray(pos, Vector3.back);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Player")
        {
            if (!Spoted && isAlive)
            {
                AudioFX.Mine.SFXSpoted();
                Spoted = true;
            }
            if (isAlive)
                Exclamation.SetActive(true);
            anim.SetBool("Detect", true);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "MainCamera")
            Destroy(gameObject);
        if (collision.collider.tag == "Weapon")
        {
            isAlive = false;

            GameObject FX = Instantiate(Effect, transform);
            FX.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

            if (!Spoted)
            {
                GameObject DisFX = Instantiate(DiscreteEffect, transform);
                DisFX.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                AudioFX.Mine.SFXDiscreteKill();
            }

            anim.SetBool("Killed", true);
            AudioFX.Mine.SFXKilled();
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
