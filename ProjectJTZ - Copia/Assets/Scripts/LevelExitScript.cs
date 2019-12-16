using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitScript : MonoBehaviour {

	public enum Level
    {
        NEXT,
        PREVIOUS,
    }

    public GameController SO_gameController;
    public Level goingTo___Map = Level.NEXT;
    public Vector3 nextLevelCoordinates = new Vector3(0, 0.1f, 0);
    public float nextLevelRotationY = 0;
    public bool active = false;

    GameObject player;
    GameObject camper;
    ScenesManager sceneManager;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camper = GameObject.Find("CamperWithMovement");
        nextLevelCoordinates.y = 0.1f;
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ScenesManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            if (other.tag == "Camper" && SO_gameController.mode == "ONCAMPER")
            {
                if (!sceneManager.isChanging)
                    MoveToLevel();
            }
        }
    }

    public void MoveToLevel()
    {
        Quaternion quat = Quaternion.Euler(new Vector3 (0, nextLevelRotationY, 0));
        player.transform.position = nextLevelCoordinates;
        camper.transform.position = nextLevelCoordinates;
        camper.transform.rotation = quat;
        camper.GetComponent<MovimentoCamperG>().acceleration = 0;

        if (goingTo___Map == Level.NEXT)
            sceneManager.currScene++;
        if(goingTo___Map == Level.PREVIOUS)
            sceneManager.currScene--;

        sceneManager.LoadSceneAdd(sceneManager.scenesNamesInOrder[sceneManager.currScene]);
    }

    public void Winnable()
    {
        active = true;
    }
}
