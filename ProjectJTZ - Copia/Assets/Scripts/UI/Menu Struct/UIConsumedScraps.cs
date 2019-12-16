using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIConsumedScraps : MonoBehaviour
{
    public IntVariable scrapsConsumed;
    public GameObject textChild;

    public void CallCoroutine()
    {
        gameObject.SetActive(true);
        StopCoroutine(DisableAfterSec());
        StartCoroutine(DisableAfterSec());
    }

    public IEnumerator DisableAfterSec()
    {
        textChild.GetComponent<Text>().text = "-" + scrapsConsumed.variable;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

}
