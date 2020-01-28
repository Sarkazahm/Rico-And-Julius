using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour {

	void Update () {
        GetComponent<Button>().onClick.AddListener(LoadMissionMenu);
	}

    void LoadMissionMenu()
    {
        SceneManager.LoadScene("MissionMenu");
    }
}
