using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToMouseBuilding : MonoBehaviour {

    public SO_Input SO_input;
    public SO_GameController gm;
	
	void Update () {

        //rotation
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            if (gameObject.tag == "Player")
            {
                transform.Rotate(Vector3.right, 90);
                transform.Rotate(Vector3.forward, 90);
            }
            else
                transform.Rotate(Vector3.up, 90);
        }

    }
}
