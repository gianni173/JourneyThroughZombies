using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {
    public SO_StatistichePlayer SO_statPlayer;
    public SO_Input SO_input;
    public Sprite shootingSprite;
    //public float mapHeight = 20f;
    //public float mapWidth = 20f;
    Rigidbody rb;
    float speed = 0;
    float maxStamina = 0;


    private void Start()
    {
        speed = SO_statPlayer.speed;
        maxStamina = SO_statPlayer.stamina;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(SO_input.sprint))
        {
            if (SO_statPlayer.stamina > 0)
            {
                speed = SO_statPlayer.sprintSpeed;
                SO_statPlayer.stamina -= SO_statPlayer.riduzioneStamina;
            }
            else
                speed = SO_statPlayer.speed;
        }
        else
        {
            speed = SO_statPlayer.speed;
            if (SO_statPlayer.stamina < maxStamina)
                SO_statPlayer.stamina += SO_statPlayer.riduzioneStamina;
            else
                SO_statPlayer.stamina = maxStamina;
        }
    }
    void FixedUpdate()
    {

        if (rb.velocity != Vector3.zero) rb.velocity = Vector3.zero;

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W) /*&& transform.position.z < mapHeight/2*/)
        {
            move += new Vector3(0,0,1);
        }
        if (Input.GetKey(KeyCode.S) /*&& transform.position.z > -(mapHeight / 2)*/)
        {
            move += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D) /*&& transform.position.x < mapWidth / 2*/)
        {
            move += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)/* && transform.position.x > -(mapWidth / 2)*/)
        {
            move += new Vector3(-1, 0, 0);

        }

        rb.velocity += move.normalized * speed;

    }

    public void PickUpUzi()
    {
        GetComponent<SpriteRenderer>().sprite = shootingSprite;
    }
}
