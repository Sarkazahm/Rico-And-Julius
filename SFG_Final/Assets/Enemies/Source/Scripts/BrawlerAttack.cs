using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerAttack : MonoBehaviour {

    [SerializeField] float damage = 10;
    private float timer = .1f;

    private void OnTriggerEnter(Collider other)
    {
        HealthController hitHealth = other.GetComponent<HealthController>();
        if (hitHealth == null || other.tag == "Enemies")
        {
            return;
        }
        else
        {
            hitHealth.TakeDamage(10);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

}
