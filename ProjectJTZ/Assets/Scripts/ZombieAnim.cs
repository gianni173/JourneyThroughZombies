using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAnim : MonoBehaviour
{
    public bool isStrisciando = false;
    public float Timer;

    ZombieMovement movement;
    ZombieAttack attack;
    ZombieStats stats;

    BoxCollider box;

    NavMeshAgent agent;
    NavMeshObstacle obstacle;

    Animator anim;

	void Start ()
    {
        box = GetComponent<BoxCollider>();
        stats = GetComponent<ZombieStats>();
        movement = GetComponent<ZombieMovement>();
        attack = GetComponent<ZombieAttack>();
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        anim = GetComponent<Animator>();
	}
	public void Death()
    {
        StartCoroutine(ZombieDeath());
    }
	public void BulletHit()
    {
        StartCoroutine(BulletHitCor());
    }
    public void Crawling()
    {
        agent.speed = agent.speed / 2;
        isStrisciando = true;
        anim.SetBool("Crawling", true);
    }
    public void Investito()
    {
        StartCoroutine(Arrotato());
    }
    IEnumerator BulletHitCor()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Hit", false);
    }
    IEnumerator ZombieDeath()
    {
        anim.SetBool("Death", true);
        // Cose da Disattivare quando muore
        movement.enabled = false;
        obstacle.enabled = false;
        agent.enabled = false;
        attack.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(Timer);
        stats.enabled = false;
        Destroy(gameObject);
    }
    IEnumerator Arrotato()
    {
        anim.SetBool("Schiacciato", true);
        // Cose da Disattivare quando muore
        movement.enabled = false;
        obstacle.enabled = false;
        agent.enabled = false;
        attack.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(Timer);
        stats.enabled = false;
        Destroy(gameObject);
    }
}
