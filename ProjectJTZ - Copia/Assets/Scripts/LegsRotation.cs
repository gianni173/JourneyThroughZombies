using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsRotation : MonoBehaviour {

    public SO_GameController SO_gameController;

    SpriteRenderer legRenderer;
    int horiz = 0;
    int vert = 0;

    private void Start()
    {
        legRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (SO_gameController.mode == "ONGROUND")
        {
            horiz = 0;
            vert = 0;

            if (Input.GetKey(KeyCode.A)) horiz -= 1;
            if (Input.GetKey(KeyCode.D)) horiz += 1;
            if (Input.GetKey(KeyCode.S)) vert -= 1;
            if (Input.GetKey(KeyCode.W)) vert += 1;

            if (horiz == 0 && vert == 0)
                legRenderer.enabled = false;
            else
                legRenderer.enabled = true;

            if (horiz == 1)
            {
                if (vert == 0)
                    transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
                if (vert == 1)
                    transform.rotation = Quaternion.LookRotation(Vector3.right + Vector3.forward, Vector3.up);
                if (vert == -1)
                    transform.rotation = Quaternion.LookRotation(Vector3.right - Vector3.forward, Vector3.up);
            }
            if (horiz == -1)
            {
                if (vert == 0)
                    transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
                if (vert == 1)
                    transform.rotation = Quaternion.LookRotation(Vector3.left + Vector3.forward, Vector3.up);
                if (vert == -1)
                    transform.rotation = Quaternion.LookRotation(Vector3.left - Vector3.forward, Vector3.up);
            }
            if (horiz == 0)
            {
                if (vert == 1)
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                if (vert == -1)
                    transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
            }


            transform.Rotate(Vector3.right, 90);
            transform.Rotate(Vector3.forward, 90);
        }
        else
            legRenderer.enabled = false;
    }
}
