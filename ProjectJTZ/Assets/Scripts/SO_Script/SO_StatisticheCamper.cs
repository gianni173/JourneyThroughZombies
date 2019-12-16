using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatisticheCamper", menuName = "StatisticheCamper")]
public class SO_StatisticheCamper : ScriptableObject {

    public float powerAccelerazione;
    public float maxSpeed;
    public float wheelsRotSpd;
    public float maxWheelsRot;
    public float friction;
    public float resistence;

    public float speedReductionOnHit;
}
