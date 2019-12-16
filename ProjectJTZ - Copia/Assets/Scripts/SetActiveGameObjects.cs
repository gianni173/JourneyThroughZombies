using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGameObjects : MonoBehaviour
{

    public GameObject[] objects;

    public void SetActiveAll()
    {
        foreach(GameObject go in objects)
        {
            go.SetActive(true);
        }
    }

}
