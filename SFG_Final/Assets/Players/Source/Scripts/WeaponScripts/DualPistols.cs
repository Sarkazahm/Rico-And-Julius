using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualPistols : MonoBehaviour {

    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletSpawnR;
    [SerializeField] GameObject bulletSpawnL;
    [SerializeField] Text ammoCountUI;
    [SerializeField] GameObject reloadTimerUI;
    [SerializeField] float reloadTime = 2;
    [SerializeField] int magazineSize = 30;
    [SerializeField] int currentBulletsInMag;
    [SerializeField] GameObject currentCharacter;
    [SerializeField] AudioSource ricoAudioSource;
    [SerializeField] AudioClip[] shootSounds;
    private GameObject currentBulletSpawn;
    [SerializeField] private bool isFiringRight = true;
    private bool isReloaded = true;
    
	void Start () {
        currentBulletsInMag = magazineSize;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Backslash) && isReloaded == true)
        {
            Fire();
        }
        if(Input.GetKeyUp(KeyCode.Backslash))
        {
            isFiringRight = !isFiringRight;
        }
        if(currentBulletsInMag<=0)
        {
            StartCoroutine(Reload());
        }
        ammoCountUI.text = currentBulletsInMag + "/" + magazineSize;


	}

    void Fire()
    {
        ricoAudioSource.clip = shootSounds[Random.Range(0, shootSounds.Length)];
        ricoAudioSource.Play();

        if(isFiringRight)
        {
            Instantiate(playerBullet, bulletSpawnR.transform.position, bulletSpawnR.transform.rotation);
        }
        if(!isFiringRight)
        {
            Instantiate(playerBullet, bulletSpawnL.transform.position, bulletSpawnR.transform.rotation);
        }

        currentBulletsInMag--;
    }

    IEnumerator Reload()
    {
        isReloaded = false;
        InitiateReloadBar();
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
        currentBulletsInMag = magazineSize;
        HideReloadBar();
    }

    void InitiateReloadBar()
    {
        reloadTimerUI.SetActive(true);
        reloadTimerUI.GetComponent<Slider>().value += (100 * Time.deltaTime) / reloadTime;
    }

    void HideReloadBar()
    {
        reloadTimerUI.GetComponent<Slider>().value = 0;
        reloadTimerUI.SetActive(false);
    }

    //UI reload bar -- amount 100*Time.deltaTime/reloadTime
}
