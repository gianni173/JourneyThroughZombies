using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public GameObject camper;
    Vector3 cursorPosition;
    Vector3 targetPos;
    Vector3 shakeOffset = Vector3.zero;
    Vector3 midVector;
    public SO_FloatVariable shakeStrenght;
    public SO_GameController gm;
    public float cameraDistanceFromPlayer = 0.2f;
    public float cameraSpeed = 0.1f;
    public float shakeTime = 2;
    public float shakeMultiplier = 1;

    bool cinemating = false;
    Vector3 startingPos = Vector3.zero;
    Vector3 endingPos;

    void Start ()
    {
        cursorPosition = Vector3.zero;
        endingPos = new Vector3(0, transform.position.y, 0);
        targetPos = Vector3.zero;
	}

	void FixedUpdate ()
    {
        if (!cinemating)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                cursorPosition = new Vector3(hit.point.x, 0, hit.point.z);
            }
            if (gm.mode == "ONGROUND")
            {
                midVector = cursorPosition - player.transform.position;
                targetPos = cameraDistanceFromPlayer * midVector + player.transform.position + shakeOffset;
            }
            else
            {
                midVector = cursorPosition - camper.transform.position;
                targetPos = cameraDistanceFromPlayer * midVector + camper.transform.position + shakeOffset;
            }

            transform.position += Vector3.right * (Difference(targetPos.x, transform.position.x) * cameraSpeed);
            transform.position += Vector3.forward * (Difference(targetPos.z, transform.position.z) * cameraSpeed);
        }
    }

    float Difference(float a, float b)
    {
        return a - b;
    }

    public void CameraShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float t = 0;
        float maxT = shakeTime;
        float shakeStrengtVal = shakeStrenght.variable;
        while (t < maxT)
        {
            t += Time.deltaTime;
            shakeOffset = new Vector3 (Random.Range(-shakeStrengtVal * shakeMultiplier, shakeStrengtVal * shakeMultiplier), 0, Random.Range(-shakeStrengtVal * shakeMultiplier, shakeStrengtVal * shakeMultiplier));
            yield return null;
        }
        shakeOffset = Vector3.zero;
    }

    public void SetEndingPosX(float x)
    {
        endingPos.x = x;
    }

    public void SetEndingPosZ(float z)
    {
        endingPos.z = z;
    }

    public void Cinematic()
    {
        StartCoroutine(CinematicCor(endingPos));
    }

    IEnumerator CinematicCor(Vector3 endingPos)
    {
        cinemating = true;
        startingPos = transform.position;
        float t = 0;
        float maxT = 2;
        float lerp = 0;
        while(t < maxT)
        {
            t += Time.deltaTime;
            lerp = t / (maxT-1);
            transform.position = new Vector3(Mathf.Lerp(startingPos.x, endingPos.x, lerp), transform.position.y, Mathf.Lerp(startingPos.z, endingPos.z, lerp));
            yield return null;
        }
        transform.position = startingPos;
        cinemating = false;
    }
}
