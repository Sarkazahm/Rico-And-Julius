using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    [SerializeField] float healAmount;
    [SerializeField] int scoreReduction = 300;
    [SerializeField] AudioClip healSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HealthController>() == null)
        {
            return;
        }
        else
        {
            HealthController otherHealth = other.GetComponent<HealthController>();
            if(otherHealth.isHealable && otherHealth.health < 100)
            {
                otherHealth.health += healAmount;
                if(otherHealth.health > 100)
                {
                    otherHealth.health = 100;
                }
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Score -= scoreReduction;
                other.GetComponent<AudioSource>().clip = healSound;
                other.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
