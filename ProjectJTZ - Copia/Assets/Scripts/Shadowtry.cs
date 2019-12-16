using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowtry : MonoBehaviour {

    public Vector3 offset = new Vector3(-3, 0, -3);

    private SpriteRenderer sprRndCaster;
    private SpriteRenderer sprRndShadow;

    private Transform transCaster;
    private Transform transShadow;

    public Material shadowMaterial;
    public Color shadowColor;

    private void Start()
    {
        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "Shadow";
        transShadow.localRotation = Quaternion.identity;

        sprRndCaster = GetComponent<SpriteRenderer>();
        sprRndShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();

        sprRndShadow.material = shadowMaterial;
        sprRndShadow.color = shadowColor;
        sprRndShadow.sortingLayerName = sprRndCaster.sortingLayerName;
        sprRndShadow.sortingOrder = sprRndCaster.sortingOrder - 1;

    }

    void LateUpdate()
    {
        transShadow.position = new Vector3(transCaster.position.x + offset.x, 0, transCaster.position.z + offset.z);
        transShadow.transform.localScale = Vector3.one;

        sprRndShadow.sprite = sprRndCaster.sprite;

    }

}

