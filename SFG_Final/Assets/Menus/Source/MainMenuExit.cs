using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuExit : MonoBehaviour {

	void Update () {
        GetComponent<Button>().onClick.AddListener(ExitGame);
	}

    void ExitGame()
    {
        Application.Quit();
    }
}
