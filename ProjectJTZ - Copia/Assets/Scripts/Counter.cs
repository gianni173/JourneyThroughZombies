using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public int counter = 0;
    public int counterTrigger = 3;
    public GameEvent triggeredEvent;

    public void AddCounter()
    {
        counter++;
        if (counter >= counterTrigger)
        {
            triggeredEvent.Raise();
            Destroy(this);
        }
    }

}
