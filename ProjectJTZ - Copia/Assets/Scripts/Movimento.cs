using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    public StatistichePlayer SO_statPlayer;
    public Input SO_input;
    public Sprite shootingSprite;

    private Rigidbody rb;
    private float speed = 0;
    private float maxStamina = 0;


    private void Start()
    {
        speed = SO_statPlayer.speed;
        maxStamina = SO_statPlayer.stamina;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(SO_input.sprint))
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

        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            move += Vector3.forward;
        }
        if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            move += Vector3.back;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            move += Vector3.right;
        }
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            move += Vector3.left;
        }

        rb.velocity += move.normalized * speed;

    }

    public void PickUpUzi()
    {
        GetComponent<SpriteRenderer>().sprite = shootingSprite;
    }

}
