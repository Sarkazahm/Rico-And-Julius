using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetHighScoreButton : MonoBehaviour {

    private void Update()
    {
        GetComponent<Button>().onClick.AddListener(InitiateReset);
    }

    void InitiateReset()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("NewHighScore", 0);
        SceneManager.LoadScene("SettingsMenu");
    }
}
