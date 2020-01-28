using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    [SerializeField] AudioSource musicManager;
    [SerializeField] AudioClip menuMusic;

    private void Awake()
    {
        musicManager.clip = menuMusic;
        musicManager.Play();
    }

    private void Update()
    {
        if(Input.GetAxis("Submit")!=0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
