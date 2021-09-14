using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    static public bool StartingGame;

    public GameObject Target;
    public float Step;

    void Start()
    {
        StartingGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartingGame)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 0)
            {
                transform.position = Vector3.Lerp(transform.position, Target.transform.position, Step/10 * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, Step / 10 * Time.deltaTime);
            }
        }
    }
}
