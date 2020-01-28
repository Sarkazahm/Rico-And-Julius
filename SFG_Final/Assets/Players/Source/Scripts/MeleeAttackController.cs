using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour {

    private float timer = .1f;
    [SerializeField] float damage = 10;
    [SerializeField] GameObject Julius;

    private void Awake()
    {
        Julius = GameObject.Find("Julius");
    }

    void Update () {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        HealthController hitHealth = other.GetComponent<HealthController>();
        if (hitHealth == null || other.tag == "Players")
        {
            return;
        }
        else
        {
            hitHealth.health -= damage + (damage * Julius.GetComponent<JuliusController>().damageModifier);
            hitHealth.TakeDamage(0, 1);
        }
    }
}
