using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyGenerator : MonoBehaviour
{
    public GameObject Ennemy;
    public GameObject LocationPoint;

    public void GenerateEnnemy()
    {
        Instantiate(Ennemy, LocationPoint.transform);
    }

}
