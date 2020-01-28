using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlleyBrawlButton : MonoBehaviour {

    private void Update()
    {
        GetComponent<Button>().onClick.AddListener(LoadAlleyBrawl);
    }

    void LoadAlleyBrawl()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
