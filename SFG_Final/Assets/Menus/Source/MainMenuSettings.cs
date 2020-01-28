using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSettings : MonoBehaviour {

	void Update () {
        GetComponent<Button>().onClick.AddListener(LoadSettingsMenu);
	}

    void LoadSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}
