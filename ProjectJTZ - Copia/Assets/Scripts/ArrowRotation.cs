using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    Transform camper;
    Transform arrow;
    Ray ray = new Ray();
    RaycastHit hit;
    
	void Start ()
    {
        arrow = GetComponent<Transform>();
        camper = GameObject.FindGameObjectWithTag("Camper").transform;

    }
	
	void Update ()
    {
        ray.origin = arrow.position;
        ray.direction = camper.position - arrow.position;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            transform.Rotate(Vector3.right, 90);
        }
    }
}
