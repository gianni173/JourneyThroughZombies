using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public List<Sprite> immagini;
    Image sfondo;
    int i = 0;

	void Start ()
    {
        sfondo = GetComponent<Image>();
        StartCoroutine(TimerChange());
    }

    void LateUpdate()
    {
        sfondo.sprite = immagini[i];
    }
    IEnumerator TimerChange()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            if (i==0)
            {
                i = 1;
            }
            else 
            {
                i = 0;
            }
        }
    }
}
