using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public GameObject gambe;
    public SO_StatistichePlayer SO_statPlayer;
    Animator anim;
    Animator animGambe;
    public float TimerMorte;

    void Start ()
    {
        anim = GetComponent<Animator>();
        animGambe = gambe.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) /*&& transform.position.z < mapHeight/2*/)
        {
            animGambe.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.S) /*&& transform.position.z > -(mapHeight / 2)*/)
        {
            animGambe.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.D) /*&& transform.position.x < mapWidth / 2*/)
        {
            animGambe.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.A)/* && transform.position.x > -(mapWidth / 2)*/)
        {
            animGambe.SetBool("walk", true);
        }
        else
        {
            animGambe.SetBool("walk", false);
        }
    }

    public void Death()
    {
        StartCoroutine(DeathPlayer());
    }
    //public void Hitted()
    //{
    //    anim.SetBool("Hit", true);
    //}
    IEnumerator DeathPlayer()
    {
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(TimerMorte);
        Destroy(gameObject);
    }

    //IEnumerator Hit()
    //{
    //    anim.SetBool("Hit", true);
    //    yield return new WaitForSeconds(1);
    //    anim.SetBool("Hit", false);

    //}
}
