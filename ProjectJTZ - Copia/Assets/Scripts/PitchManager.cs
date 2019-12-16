using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchManager : MonoBehaviour
{
    public StatisticheCamper SO_statisticheCamper;
    public GameObject camper;
    public float minPitch = 0.8f;
    public float maxPitch = 1.5f;

    float maxSpeed;
    
	void Start ()
    {
        maxSpeed = SO_statisticheCamper.maxSpeed;
	}
	
	void Update ()
    {
        CalculatePitch();
	}
     
    void CalculatePitch()
    {
        float accel = camper.GetComponent<MovimentoCamperG>().acceleration;
        GetComponent<AudioSource>().pitch = minPitch + ((maxPitch - minPitch) * (accel*Mathf.Sign(accel) / maxSpeed));
    }
}
