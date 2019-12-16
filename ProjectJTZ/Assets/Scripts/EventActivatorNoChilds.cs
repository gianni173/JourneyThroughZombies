using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventActivatorNoChilds : MonoBehaviour
{

    public GameEvent[] eventList;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            foreach(GameEvent ge in eventList)
            {
                ge.Raise();
            }
            Destroy(gameObject);
        }
    }

}
