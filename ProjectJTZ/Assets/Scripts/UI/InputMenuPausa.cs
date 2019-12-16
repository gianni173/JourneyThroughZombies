using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMenuPausa : MonoBehaviour
{

    ScenesManager scenesManager;

    private void Start()
    {
        scenesManager = GameObject.Find("ScenesManager").GetComponent<ScenesManager>();
    }

    public void Resume()
    {
        scenesManager.Resume();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SCENA MADRE");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
