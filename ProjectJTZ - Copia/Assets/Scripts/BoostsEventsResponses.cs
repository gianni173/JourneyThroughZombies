using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsEventsResponses : MonoBehaviour {

    public GameEvent ConsumeResEvent;
    public float healPanino = 10;
    public GameObject esca;
    public GameController SO_gameManager;
    public GameEvent tutorialFullHealth;

    bool tutorialFirstFull = true;

	public void HealPanino()
    {
        ConsumeResEvent.Raise();
        SO_gameManager.playerHp += healPanino;
        if (SO_gameManager.playerHp > 100)
        {
            if (tutorialFirstFull)
            {
                tutorialFullHealth.Raise();
                tutorialFirstFull = false;
            }
            SO_gameManager.playerHp = 100;
        }
    }

    public void DropEsca()
    {
        if (SO_gameManager.mode != "ONCAMPER")
        {
            ConsumeResEvent.Raise();
            Instantiate(esca, transform.position - Vector3.up * 0.02f, transform.rotation);
        }
    }

}
