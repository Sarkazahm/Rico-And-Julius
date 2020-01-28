using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float bulletSpeed = 10f;
    public float damageAmount = 10f;
    [SerializeField] float bulletLifeTime = 0.2f;

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward*bulletSpeed);
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime<0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<HealthController>() != null)
        {
            if(collision.transform.tag == "Players")
            {
                Debug.Log("Friendly Fire");
                Destroy(gameObject);
            }
            else if(collision.transform.tag == "Enemies")
            {
                collision.transform.GetComponent<HealthController>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
