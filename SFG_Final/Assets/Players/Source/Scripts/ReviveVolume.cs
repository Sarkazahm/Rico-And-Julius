using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReviveVolume : MonoBehaviour {

    [SerializeField] int playersInReviveRange;
    [SerializeField] public bool isRevivable = false;
    [SerializeField] public float reviveProgress = 0;

	void Update () {
		if(playersInReviveRange>=2)
        {
            isRevivable = true;
        }
        if(playersInReviveRange<2)
        {
            isRevivable = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Players")
        {
            playersInReviveRange++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Players")
        {
            playersInReviveRange--;
        }
    }


}
