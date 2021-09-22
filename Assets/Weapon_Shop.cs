using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shop : MonoBehaviour
{
    public GameObject[] Skins;
    public int idx;

    public float speed;

    Vector3 scale;

    void Start()
    {
        for (int i = 0; i < Skins.Length; i++)
            Skins[i].SetActive(false);
        Skins[idx].SetActive(true);

        scale = transform.localScale;
    }

    void Update()
    {
        if (Shop.Mine.getIdxWeapon() == idx && transform.localScale.magnitude < scale.magnitude * 1.5f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 1.5f, Time.deltaTime * speed);
        }
        else if (Shop.Mine.getIdxWeapon() != idx && transform.localScale.magnitude > scale.magnitude)
            transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * speed);
    }
}
