using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OofBoxController : MonoBehaviour {

    private float time = 0.1f;

    private void Update()
    {
        time -= Time.deltaTime;
        if(time<0)
        {
            Destroy(gameObject);
        }
    }
}
