using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour {

    [SerializeField] Text highScore;
    [SerializeField] int newHighScore;
    private float timer = 2f;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("NewHighScore") > PlayerPrefs.GetInt("HighScore"))
        {
            newHighScore = PlayerPrefs.GetInt("NewHighScore");
            PlayerPrefs.SetInt("HighScore", newHighScore);
            highScore.text = "New High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
                Debug.Log("Enter");
            }
        }
    }
}
