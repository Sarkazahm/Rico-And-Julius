using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;
    
	void Awake () {
		if(instance==null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance!=null)
        {
            Destroy(gameObject);
        }
	}
	
	void Update () {
		
	}
}
