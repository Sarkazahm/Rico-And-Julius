using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

}
