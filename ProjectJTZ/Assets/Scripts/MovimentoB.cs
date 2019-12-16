using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoB : MonoBehaviour {

    public float speed;
    //public float mapHeight = 20f;
    //public float mapWidth = 20f;

    Movimento moveSetA;

    private void Start()
    {
        moveSetA = GetComponent<Movimento>();
    }

    private void Update()
    {
        //if (transform.position.z > mapHeight / 2)
        //    transform.position = new Vector3(transform.position.x, transform.position.y, mapHeight / 2);
        //if (transform.position.z < -(mapHeight / 2))
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -(mapHeight / 2));
        //if (transform.position.x > mapWidth / 2)
        //    transform.position = new Vector3(mapWidth /2, transform.position.y, transform.position.z);
        //if (transform.position.x < -(mapWidth / 2))
        //    transform.position = new Vector3(-(mapWidth / 2), transform.position.y, transform.position.z);

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            moveSetA.enabled = true;
            this.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)/* && transform.position.z < mapHeight / 2*/)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) /*&& transform.position.z > -(mapHeight / 2)*/)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) /*&& transform.position.x < mapWidth / 2*/)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) /*&& transform.position.x > -(mapWidth / 2)*/)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}
