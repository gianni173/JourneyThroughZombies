using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public string[] scenesNamesInOrder;
    public Vector3[] scenesSpawnPointsInOrder;

    public GameObject cameraMain;
    public GameObject player;
    public GameObject camper;
    public SO_Input SO_input;
    public AudioSource[] audioEmittersPausable;
    public GameObject[] gameObjPausable;
    public Image fader;
    public GameObject faderBg;
    public SO_BoolVariable fuelVar;
    public SO_IntVariable projCount;

    [HideInInspector]
    public Dictionary<string, Scene> loadedScenes = new Dictionary<string, Scene>();
    [HideInInspector]
    public int currScene = 0;
    [HideInInspector]
    public bool isChanging = false;

    float volume = 0;
    bool debugging = false;
    bool isPaused = false;
    GameObject[] objects;


    void Start ()
    {
        projCount.variable = 0;
        fuelVar.variable = false;
        loadedScenes.Clear();
        LoadSceneAdd(scenesNamesInOrder[currScene]);
	}

    void Update()
    {
        if (!isChanging)
        {
            if (Input.GetKeyDown(SO_input.pausa))
            {
                if (!isPaused)
                {
                    LoadSceneAdd("PauseScene");
                    foreach (AudioSource aud in audioEmittersPausable)
                    {
                        volume = aud.volume;
                        aud.volume = 0;
                    }
                    foreach (GameObject go in gameObjPausable)
                    {
                        go.SetActive(false);
                    }
                    isPaused = !isPaused;
                }
                else
                {
                    Resume();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && currScene > 0)
            {
                currScene--;
                debugging = true;
                LoadSceneAdd(scenesNamesInOrder[currScene]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && currScene < (scenesNamesInOrder.Length - 1))
            {
                currScene++;
                debugging = true;
                LoadSceneAdd(scenesNamesInOrder[currScene]);
            }
        }
    }

    public void LoadSceneAdd(string sceneName)
    {
        //disable objects in previous room
        if (!(SceneManager.GetActiveScene().name == "SCENA MADRE"))
        {
            objects = SceneManager.GetActiveScene().GetRootGameObjects();
            //print("disabling " + SceneManager.GetActiveScene().name);
            foreach (GameObject go in objects)
                go.SetActive(false);
        }

        StartCoroutine(FadeIn(sceneName));
    }

    IEnumerator SetSceneActive(Scene scene)
    {
        while (!scene.isLoaded)
            yield return null;
        SceneManager.SetActiveScene(scene);
        //enable objects in next room
        objects = SceneManager.GetActiveScene().GetRootGameObjects();
        //print("enabling " + SceneManager.GetActiveScene().name);
        foreach (GameObject go in objects)
        {
            go.SetActive(true);
        }
        ZombieSpawner[] zSpawns = FindObjectsOfType<ZombieSpawner>();
        foreach (ZombieSpawner zs in zSpawns)
                zs.spawnTimes = zs.maxSpawnTimes;
    }

    IEnumerator FadeIn(string sceneName)
    {
        isChanging = true;
        float t = 0;
        float maxT = 1f;
        float lerp = 0;
        faderBg.SetActive(true);
        while (t < maxT)
        {
            t += Time.deltaTime;
            lerp = t / maxT;
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, lerp);
            yield return null;
        }
        if (!loadedScenes.ContainsKey(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            loadedScenes.Add(sceneName, SceneManager.GetSceneByName(sceneName));
        }
        StartCoroutine(SetSceneActive(loadedScenes[sceneName]));

        faderBg.SetActive(false);
        if (debugging)
        {
            camper.transform.position = scenesSpawnPointsInOrder[currScene];
            player.transform.position = scenesSpawnPointsInOrder[currScene] + Vector3.back * 2;
            cameraMain.transform.position = new Vector3(player.transform.position.x, cameraMain.transform.position.y, player.transform.position.z);
        }
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float maxT = 1f;
        float t = maxT;
        float lerp = 1;
        cameraMain.transform.position = new Vector3(player.transform.position.x, cameraMain.transform.position.y, player.transform.position.z);
        while (t > 0)
        {
            t -= Time.deltaTime;
            lerp = t / maxT;
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, lerp);
            yield return null;
        }
        isChanging = false;
        debugging = false;
    }

    public void Resume()
    {
        if (!isChanging)
        {
            LoadSceneAdd(scenesNamesInOrder[currScene]);
            foreach (AudioSource aud in audioEmittersPausable)
            {
                aud.volume = volume;
            }
            foreach (GameObject go in gameObjPausable)
            {
                go.SetActive(true);
            }
            isPaused = !isPaused;
        }
    }

    public void DestroyAllZ()
    {
        objects = SceneManager.GetActiveScene().GetRootGameObjects();
        //print("enabling " + SceneManager.GetActiveScene().name);
        foreach (GameObject go in objects)
        {
            if (go.tag == "Zombie")
                Destroy(go);
        }
    }
}
