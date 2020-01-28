using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    [SerializeField] Text highScoreText;
    [SerializeField] public int Score;

    private void Update()
    {
        highScoreText.text = "Score: " + Score;
    }
}
