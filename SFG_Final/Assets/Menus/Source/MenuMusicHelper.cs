using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicHelper : MonoBehaviour {

    [SerializeField] AudioSource menuMusicSource;
    [SerializeField] AudioClip menuMusic;

	void Start () {
        menuMusicSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        if(menuMusicSource.clip != menuMusic)
        {
            menuMusicSource.clip = menuMusic;
            menuMusicSource.Play();
        }

	}

}
