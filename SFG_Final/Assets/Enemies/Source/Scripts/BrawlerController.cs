using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthController))]
public class BrawlerController : MonoBehaviour {

     NavMeshAgent brawlerNavAgent;
     HealthController brawlerHealthController;
    [SerializeField] float distanceToCurrentTarget;
    [SerializeField] Vector3 currentTarget;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject attackObjectSpawn;
    [SerializeField] GameObject attackObject;
    [SerializeField] float detectionDistance = 20;
    [SerializeField] float attackTimeInterval = 0.5f;
    [SerializeField] bool isEngaged = false;
    [SerializeField] bool isAttacking = false;
    [SerializeField] bool canAttack = true;
    [SerializeField] int scoreAmount = 100;
    
    void Awake () {
        brawlerNavAgent = GetComponent<NavMeshAgent>();
        brawlerHealthController = GetComponent<HealthController>();
	}
	
	void Update () {
        FindTarget();
        if(isEngaged)
        {
            SeekTarget();
        }

        if(isAttacking && canAttack && !GetComponent<HealthController>().isStunned)
        {
            StartCoroutine(Attack());
        }

        if(brawlerHealthController.isDead)
        {
            DeathEvents();
        }
	}

    void FindTarget()
    {     
        float player1Distance = Vector3.Distance(transform.position, player1.transform.position);
        float player2Distance = Vector3.Distance(transform.position, player2.transform.position);

        if (player1Distance < detectionDistance || player2Distance < detectionDistance)
        {
            isEngaged = true;
            if (player1.GetComponent<PlayerController>().isDowned)
            {
               currentTarget = player2.transform.position;
            }
            else
            {
                if (player2.GetComponent<PlayerController>().isDowned)
                {
                    currentTarget = player1.transform.position;
                }
            }
            if(!player1.GetComponent<PlayerController>().isDowned && !player2.GetComponent<PlayerController>().isDowned)
            {
                if(player1Distance < player2Distance)
                {
                    currentTarget = player1.transform.position;
                }
                else
                {
                    currentTarget = player2.transform.position;
                }
            }
            distanceToCurrentTarget = Vector3.Distance(transform.position, currentTarget);
        }
        else
        {
            isEngaged = false;
        }
    }

    void SeekTarget()
    {
        brawlerNavAgent.SetDestination(currentTarget);
        if(distanceToCurrentTarget<3)
        {
            brawlerNavAgent.isStopped = true;
            isAttacking = true;
        }
        else
        {
            brawlerNavAgent.isStopped = false;
            isAttacking = false;
        }
    }

    void DeathEvents()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Score += scoreAmount;
        Destroy(gameObject);
    }

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackTimeInterval);
        Instantiate(attackObject, attackObjectSpawn.transform.position, attackObjectSpawn.transform.rotation);
        canAttack = true;
    }
}
