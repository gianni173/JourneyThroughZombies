using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float range = 4f;
    public int damage;
    public GameObject aoeExploder;

    bool exploded = false;
    float t = 0f;

    void Update () {

        t += Time.deltaTime;
        if (t > range)
        {
            if (aoeExploder != null)
            {
                speed = 0;
                GetComponent<SpriteRenderer>().enabled = false;
                aoeExploder.SetActive(true);
                Explode();
            }
            else
                Destroy(gameObject);
        }
        transform.position += transform.right * speed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enviroment")
        {
            //print(other.name);
            if (aoeExploder != null)
            {
                aoeExploder.SetActive(true);
                Explode();
            }
            else
                Destroy(gameObject);
        }

        if (other.tag == "Zombie")
        {
            //print(other.name);
            ZombieStats stats = other.GetComponent<ZombieStats>();
            ZombieAnim anim = other.GetComponent<ZombieAnim>();
            stats.hp -= damage;
            if(stats.hp > 0 && aoeExploder == null)
                anim.BulletHit();
            if (stats.SO_statZ.striscia)
            {
                if (stats.hp <= (stats.SO_statZ.hp/2) && !anim.isStrisciando)
                {
                    anim.Crawling();
                }
            }

            if (aoeExploder != null)
            {
                aoeExploder.SetActive(true);
                Explode();
            }
            else
                Destroy(gameObject);
        }
    }

    void Explode()
    {
        StartCoroutine(ExplodeCor());
    }

    IEnumerator ExplodeCor()
    {
        speed = 0;
        yield return new WaitForSeconds(0.1f);

        if (!exploded)
        {
            aoeExploder.GetComponent<EsplosioneProiettile>().DamageAll();
            exploded = true;
        }

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}