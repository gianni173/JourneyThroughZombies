using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nameSceneLoaded = "SCENA MADRE";
    public GameEvent startMusicaEvent;

    private void Start()
    {
        startMusicaEvent.Raise();
    }

    public void OnclickStart()
    {
        StartCoroutine(LoadScene());          
    }
    public void OnclickQuit()
    {
        Application.Quit();
    }
    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameSceneLoaded);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
