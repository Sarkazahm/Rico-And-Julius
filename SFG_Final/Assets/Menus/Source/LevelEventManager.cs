using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEventManager : MonoBehaviour {

    private AudioSource musicManager;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] HealthController player1;
    [SerializeField] HealthController player2;
    [SerializeField] GameObject enemies;
    [SerializeField] int currentScore;

    private int currentHighScore = 0;

    private void Awake()
    { 
        currentHighScore = PlayerPrefs.GetInt("HighScore");
        musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        musicManager.clip = gameMusic;
        musicManager.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        enemies = GameObject.FindGameObjectWithTag("Enemies");
        if (player1.isDead && player2.isDead)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (enemies == null)
        {
            currentScore = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Score;
            if ( currentScore > currentHighScore)
            {
                PlayerPrefs.SetInt("NewHighScore", currentScore);
            }
            LoadWinScene();
        }
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
