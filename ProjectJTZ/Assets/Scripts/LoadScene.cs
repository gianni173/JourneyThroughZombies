using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    bool winnable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (winnable)
        {
            if (other.tag == "Camper" || other.tag == "Player")
                Load();

        }
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Winnable()
    {
        winnable = true;
    }

}
