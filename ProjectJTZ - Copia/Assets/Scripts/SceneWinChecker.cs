using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWinChecker : MonoBehaviour
{

    public GameEvent sceneWinEvent;

    private void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Zombie"))
        {
            sceneWinEvent.Raise();
            Destroy(gameObject);
        }
    }

}
