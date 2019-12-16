using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherMenuPosition : MonoBehaviour
{
    public Vector3 pos;
    public GameObject lowPos;
    public GameObject[] occupyThings;

    bool goDown = false;

    private void Start()
    {
        pos = transform.localPosition;
    }

    private void Update()
    {
        goDown = false;
        foreach (GameObject go in occupyThings)
        {
            if (go.activeInHierarchy)
            {
                goDown = true;
            }
        }

        if (goDown)
            transform.localPosition = lowPos.transform.localPosition;
        else
            transform.localPosition = pos;
    }

}
