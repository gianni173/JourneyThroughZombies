using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamperG : MonoBehaviour {

    public SO_StatisticheCamper SO_StatCamper;
    public Rigidbody rb;
    public SO_GameController gm;
    public GameObject[] RotatingWheels;
    public float volumeArrotato;
    public float speedNecessariaCrashBarricate = 2;
    public GameEvent TutorialNoFuelEvent;

    AudioSource audioPlayer;

    [HideInInspector]
    public float acceleration = 0;

    float wheelsRot = 0;
    bool tutorialTrigger = false;

    private void Start()
    {
        audioPlayer = GameObject.Find("SFX OneShot").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //movimento ruote
        foreach(GameObject wheel in RotatingWheels)
        {
            float euler_y = transform.rotation.eulerAngles.y;
            wheel.transform.rotation = Quaternion.Euler(90, euler_y + (45 * wheelsRot), 0);
        }

        //movimento camper
        if (wheelsRot != 0)
            wheelsRot -= (SO_StatCamper.wheelsRotSpd / 2) * Mathf.Sign(wheelsRot);
        if (acceleration != 0)
            acceleration -= (SO_StatCamper.friction) * Mathf.Sign(acceleration);

        if (gm.camperFuel > 0)
        {
            if (Input.GetKey(KeyCode.W) && acceleration < SO_StatCamper.maxSpeed)
                acceleration += SO_StatCamper.powerAccelerazione;
            if (Input.GetKey(KeyCode.S) && acceleration > -(SO_StatCamper.maxSpeed / 3) * 2)
                acceleration -= SO_StatCamper.powerAccelerazione;
        }

        if (gm.camperFuel <= 0)
        {
            if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S))))
            {
                if(!tutorialTrigger)
                {
                    TutorialNoFuelEvent.Raise();
                    tutorialTrigger = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.D) && wheelsRot < SO_StatCamper.maxWheelsRot)
            wheelsRot += SO_StatCamper.wheelsRotSpd;
        if (Input.GetKey(KeyCode.A) && wheelsRot > -SO_StatCamper.maxWheelsRot)
            wheelsRot -= SO_StatCamper.wheelsRotSpd;

        if (wheelsRot < SO_StatCamper.wheelsRotSpd / 2 && wheelsRot > -SO_StatCamper.wheelsRotSpd / 2)
            wheelsRot = 0;
        if (acceleration < SO_StatCamper.friction && acceleration > -SO_StatCamper.friction)
            acceleration = 0;
    }

    void FixedUpdate () {

        rb.velocity = transform.right * -acceleration;
        if (gm.camperFuel > 0)
        {
            gm.camperFuel -= gm.FuelConsumption * (Mathf.Sign(acceleration) * acceleration);
        }
        rb.angularVelocity = Vector3.zero;

        transform.Rotate(Vector3.up, wheelsRot*acceleration);

	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Zombie" && (acceleration > 2 || acceleration < -2))
        {
            audioPlayer.PlayOneShot(collision.collider.GetComponent<ZombieStats>().SO_statZ.arrotato, volumeArrotato);
            collision.collider.GetComponent<ZombieStats>().hp -= 10000;
            ZombieAnim anim = collision.collider.GetComponent<ZombieAnim>();
            anim.Investito();
            gm.camperFuel -= 1;
            if(acceleration > 0)
                acceleration -= SO_StatCamper.speedReductionOnHit;
            if(acceleration < 0)
                acceleration += SO_StatCamper.speedReductionOnHit;
        }

        if(collision.collider.tag == "TargetStructure" && (acceleration > speedNecessariaCrashBarricate || acceleration < -speedNecessariaCrashBarricate))
        {
            audioPlayer.PlayOneShot(collision.collider.GetComponent<Struttura>().stats.explosionDestruction, collision.collider.GetComponent<Struttura>().stats.volumeDistruzione);
            Destroy(collision.collider.gameObject);
        }
    }
}
