using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JuliusSwordArt : MonoBehaviour {

    private float swingRate = 25f;
    private float timer = .2f;

    private void Start()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, (Random.Range(0, 360))), Space.World);
        gameObject.transform.Rotate(new Vector3(-90, 0, 0), Space.Self);

    }
    void Update () {
        gameObject.transform.Rotate(new Vector3(swingRate, 0, 0), Space.Self);
        swingRate +=Time.deltaTime;
        timer -= Time.deltaTime;

        if(timer<0)
        {
            Destroy(gameObject);
        }
    }
}
