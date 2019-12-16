using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputEndingScene : MonoBehaviour
{
    public KeyCode returnToMenuKey;
    public string menuSceneName;

	void Update ()
    {
        if (Input.GetKeyDown(returnToMenuKey))
            SceneManager.LoadScene(menuSceneName);
	}
}
