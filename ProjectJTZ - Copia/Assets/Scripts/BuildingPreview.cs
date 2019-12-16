using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingPreview : MonoBehaviour {

    public InventarioOggetti SO_structList;
    public GameController SO_GM;
    public HUDTextsReferences hudRef;
    public Input SO_input;
    public float distFromPlayer;
    public float rotationSpd = 1;
    public Color placeableColor;
    public Color notPlaceableColor;
    public AudioSource audioPlayer;
    public GameEvent placedBuildingEvent;

    [HideInInspector]
    public StructureTemplate selectedStruct;

    float rotation = 90;
    List<Collider> triggerColliders = new List<Collider>();
    GameObject spawned = null;
    bool placeable = false;
    bool enoughRes = true;
    int index = 0;

    private void OnEnable()
    {
        NewStructure();
    }

    void Update () {

        if (enoughRes)
            CheckPlaceablePlace(); //migliorabile con un evento.Raise() nel PreviewCollisions!
        spawned.transform.position = transform.position + transform.right * distFromPlayer;
        spawned.transform.LookAt(transform);
        spawned.transform.Rotate(Vector3.right, 90);
        spawned.transform.Rotate(Vector3.forward, rotation);

        if (UnityEngine.Input.GetKey(SO_input.ruotaBuildOrario))
            rotation += rotationSpd;
        if (UnityEngine.Input.GetKey(SO_input.ruotaBuildAntiorario))
            rotation -= rotationSpd;

        //piazza la struttura
        if(UnityEngine.Input.GetKeyDown(SO_input.piazzamento) && placeable)
        {
            PlaceStructure();
            audioPlayer.PlayOneShot(SO_structList.ListaStruct[index].buildingSound);
            SO_GM.scraps -= SO_structList.ListaStruct[index].scrapsReq;
            SO_GM.food -= SO_structList.ListaStruct[index].foodReq;
            NewStructure();

        }

        //scroll tra la lista di oggetti
        if (UnityEngine.Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (index < SO_structList.ListaStruct.Count - 1)
                index++;
            else
                index = 0;

            DestroyStructure();
            NewStructure();
        }

        if (UnityEngine.Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (index > 0)
                index--;
            else
                index = SO_structList.ListaStruct.Count - 1;

            DestroyStructure();
            NewStructure();
        }
    }

    private void OnDisable()
    {
        DestroyStructure();
    }

    void CheckPlaceableResources()
    {
        if (SO_GM.scraps >= SO_structList.ListaStruct[index].scrapsReq && SO_GM.food >= SO_structList.ListaStruct[index].foodReq)
            enoughRes = true;
        else
        {
            enoughRes = false;
            placeable = false;
            spawned.GetComponent<SpriteRenderer>().color = notPlaceableColor;
        }
    }

    void CheckPlaceablePlace()
    {
        if (spawned.GetComponent<PreviewCollisions>().collidingThings > 0)
        {
            placeable = false;
            spawned.GetComponent<SpriteRenderer>().color = notPlaceableColor;
        }
        else
        {
            placeable = true;
            spawned.GetComponent<SpriteRenderer>().color = placeableColor;
        }
    }

    void NewStructure()
    {
        triggerColliders.Clear();
        spawned = Instantiate(SO_structList.ListaStruct[index].prefab, transform.position + transform.right * distFromPlayer, transform.rotation);
        selectedStruct = SO_structList.ListaStruct[index];
        hudRef.boostName = selectedStruct.buildingName;
        hudRef.scrapsReq = selectedStruct.scrapsReq;
        hudRef.foodReq = selectedStruct.foodReq;
        CheckPlaceableResources();
        GetTriggerColliders(spawned);
        spawned.GetComponent<Collider>().isTrigger = true;
        spawned.AddComponent<PreviewCollisions>();
        if(spawned.GetComponent<NavMeshObstacle>())
            spawned.GetComponent<NavMeshObstacle>().enabled = false;
        if (spawned.GetComponent<Animator>())
            spawned.GetComponent<Animator>().enabled = false;
    }

    void PlaceStructure()
    {
        placedBuildingEvent.Raise();
        SO_structList.ListaStruct[index].CopyValues(SO_structList.ListaStruct[index], spawned.GetComponent<Struttura>().stats);
        spawned.GetComponent<Collider>().isTrigger = false;
        foreach(Collider cl in triggerColliders)
        {
            cl.isTrigger = true;
        }
        spawned.GetComponent<Struttura>().placed = true;
        spawned.GetComponent<PreviewCollisions>().enabled = false;
        spawned.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        if (spawned.GetComponent<NavMeshObstacle>())
            spawned.GetComponent<NavMeshObstacle>().enabled = true;
        if (spawned.GetComponent<Animator>())
            spawned.GetComponent<Animator>().enabled = true;
        if (spawned.GetComponent<Mina>())
            spawned.GetComponent<Mina>().ActivateMineCollider();
    }

    void GetTriggerColliders(GameObject structure)
    {
        Collider[] current = structure.GetComponents<Collider>();
        foreach (Collider cl in current)
        {
            if (cl.isTrigger)
            {
                triggerColliders.Add(cl);
            }
        }
    }

    void DestroyStructure()
    {
        Destroy(spawned);
        spawned = null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "TargetStructure")
        {
            if(UnityEngine.Input.GetKeyDown(SO_input.interazione))
            {
                audioPlayer.PlayOneShot(collision.collider.GetComponent<Struttura>().stats.explosionDestruction, collision.collider.GetComponent<Struttura>().stats.volumeDistruzione);
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
