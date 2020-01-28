using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuExit : MonoBehaviour
{

    void Update()
    {
        GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}