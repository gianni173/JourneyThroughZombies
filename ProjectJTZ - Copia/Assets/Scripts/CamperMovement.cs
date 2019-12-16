using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamperMovement : MonoBehaviour {
    Rigidbody rb;
    float acceleration = 5f;
    //float steerinPower = 5f;
    float SteeringAmount, speed, direction;
    float currentTurn = Mathf.Clamp(360, -45, 45);
    float turnAngle = 90f;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
    private void Update()
    {
        speed = Input.GetAxis("Vertical") * acceleration;

        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                currentTurn = turnAngle * Time.deltaTime;
                rb.rotation = Quaternion.Euler(rb.transform.eulerAngles + new Vector3(0, currentTurn, 0));
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                currentTurn = turnAngle * Time.deltaTime;
                rb.rotation = Quaternion.Euler(rb.transform.eulerAngles + new Vector3(0, -currentTurn, 0));
            }
            else
            {
                currentTurn = 0;
            }
        }

    }
    void FixedUpdate ()
    {
        //speed = Input.GetAxis("Vertical") * acceleration;

        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.left * speed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(Vector3.left * speed);
        }

    }
}
