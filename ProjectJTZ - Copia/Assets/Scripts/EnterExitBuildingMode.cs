using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitBuildingMode : MonoBehaviour{

    public GameController gm;
    public Input SO_input;
    public GameEvent SO_switchToBuilding;
    public GameEvent SO_switchToCombat;
    //Animator anim;

    void Update () {
		
        if(gm.mode == "ONGROUND")
        {
            if (gm.playerMode == "COMBAT")
            {
                if (UnityEngine.Input.GetKeyDown(SO_input.switchSparoBuilding))
                {
                    SO_switchToBuilding.Raise();
                    gm.playerMode = "BUILDING";
                    GetComponent<Animator>().SetBool("Building", true);
                }
            }
            else if (gm.playerMode == "BUILDING")
            {
                if (UnityEngine.Input.GetKeyDown(SO_input.switchSparoBuilding))
                {
                    SO_switchToCombat.Raise();
                    gm.playerMode = "COMBAT";
                    GetComponent<Animator>().SetBool("Building", false);
                }
            }
        }
	}
}
