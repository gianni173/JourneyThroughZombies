using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour {

    public static Singletons instance = null;

    void Awake() {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
