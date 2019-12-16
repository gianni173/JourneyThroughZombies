using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPickUpText : MonoBehaviour
{

    [HideInInspector]
    public string textShowed = "";

    Vector3 startingPos;

	void Start ()
    {
        startingPos = transform.position;
        transform.Rotate(Vector3.right, -90);
        StartCoroutine(MoveUpAndFade());
	}

    IEnumerator MoveUpAndFade()
    {
        float t = 0;
        float maxT = 2f;
        float lerp = 0;
        while (t < maxT)
        {
            t += Time.deltaTime;
            lerp = t/maxT;
            transform.position = new Vector3(startingPos.x, startingPos.y, Mathf.Lerp(startingPos.z, startingPos.z + 2, lerp));
            yield return null;
        }
        Destroy(gameObject);
    }
}
