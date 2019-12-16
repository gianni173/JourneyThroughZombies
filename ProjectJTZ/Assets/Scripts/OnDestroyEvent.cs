using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEvent : MonoBehaviour
{

    public GameEvent destroyedBarricade;

    private void OnDestroy()
    {
        destroyedBarricade.Raise();
    }

}
