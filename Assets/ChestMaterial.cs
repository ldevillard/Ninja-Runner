using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMaterial : MonoBehaviour
{

    public Material[] ChestMat;

    void Start()
    {
        int i = Random.Range(0, ChestMat.Length);
        GetComponent<Renderer>().material = ChestMat[i];
    }
}
