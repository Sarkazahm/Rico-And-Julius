using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float timeModifier = 0.05f;
    public bool isInBulletTime = false;
    private bool isInCoroutine = false;
    private float bulletTimeLengthClass;

    public void BulletTime(float bulletTimeLengthLocal)
    {
        isInBulletTime = true;
        bulletTimeLengthClass = bulletTimeLengthLocal;
         if (isInBulletTime && !isInCoroutine)
         {
                StartCoroutine(BulletTimeLength());
         }
    }

    IEnumerator BulletTimeLength()
    {
        isInCoroutine = true;
        Time.timeScale = timeModifier;
        
        yield return new WaitForSeconds(bulletTimeLengthClass);
        Time.timeScale = 1f;
        isInCoroutine = false;
        isInBulletTime = false;
    }
}
