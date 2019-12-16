using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{

    public GameEvent eventToRaise;

    private void Start()
    {
        eventToRaise.Raise();
    }
}
