using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public float health;
    public bool isStunned = false;
    public bool isDead = false;
    [SerializeField] public bool isHealable = false;
    [SerializeField] Slider healthUI;
    [SerializeField] GameObject oofBox;
    [SerializeField] AudioSource oofSoundSource;
    [SerializeField] AudioClip oofSound;
    [SerializeField] AudioClip deathSound;
    private float stunTime;
    private bool soundPlayed = false;

	void Update () {
		if(health <= 0)
        {
            isDead = true;
            if(!soundPlayed)
            {
                oofSoundSource.clip = deathSound;
                oofSoundSource.Play();
                soundPlayed = true;
            }
        }
        if(health>0)
        {
            soundPlayed = false;
        }
        if(healthUI == null)
        {
            return;
        }
        else
        {
            healthUI.value = health;
        }
	}

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Instantiate(oofBox, gameObject.transform.position, gameObject.transform.rotation);  
        if(oofSound!=null)
        {
            oofSoundSource.clip = oofSound;
            oofSoundSource.Play();
        }
    }
    public void TakeDamage(float damageAmount, float stuntime)
    {
        health -= damageAmount;
        stunTime = stuntime;
        Instantiate(oofBox, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine(Stun());
    }
    IEnumerator Stun()
    {
        isStunned = true;
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
    }
}
