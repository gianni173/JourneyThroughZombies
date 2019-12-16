using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherMenus : MonoBehaviour
{
    public void CallCoroutine()
    {
        gameObject.SetActive(true);
        StopCoroutine(DisableAfterSec());
        StartCoroutine(DisableAfterSec());
    }

    public IEnumerator DisableAfterSec()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
	
}
