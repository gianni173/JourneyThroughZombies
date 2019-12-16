using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite sprite;

    public void ChangeSpr()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
