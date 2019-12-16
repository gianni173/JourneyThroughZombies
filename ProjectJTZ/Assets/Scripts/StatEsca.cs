using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatEsca : MonoBehaviour
{
    NavMeshAgent navmeshagent;
    public float hp = 5f;
    public float range = 0.2f;
    public float speed = 0.2f;

    [HideInInspector]
    public List<GameObject> zombieAggrati = new List<GameObject>();

    float t = 0f;

    void Start()
    {
        zombieAggrati.Clear();
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > range)
        {
            Stop();
        }
        transform.position += transform.right * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            ZombieMovement movScript = other.GetComponent<ZombieMovement>();
            movScript.target = gameObject;
            movScript.SetDestination();
            zombieAggrati.Add(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enviroment" || collision.collider.tag == "Camper")
            t = range;

        if (collision.collider.tag == "Player")
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());

        if (collision.collider.tag == "Camper" && speed == 0)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    void Stop()
    {
        speed = 0;
    }
}
