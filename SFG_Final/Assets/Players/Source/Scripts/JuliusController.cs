using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class JuliusController : MonoBehaviour
{
    [SerializeField] float comboTimer;
    [SerializeField] float heavyAttackTracker;
    [SerializeField] float comboTracker;
    [SerializeField] float damageModifierStack = 0.5f;
    [SerializeField] float attackDashSpeed = 300f;
    [SerializeField] float dashSpeed = 500f;
    [SerializeField] float dashResetTimer = 1f;

    private bool resetDashCheck = true;
    private bool quickAttackResetCheck = true;
    public float damageModifier;

    [Header("Attack Setup")]
    [SerializeField] GameObject artObjectSpawn;
    [SerializeField] GameObject artObject;
    [SerializeField] GameObject heavyArtObject;
    [SerializeField] GameObject attackObjectSpawnObject;
    [SerializeField] GameObject attackObject;
    [SerializeField] GameObject heavyAttackObject;
    [SerializeField] Rigidbody JuliusRB;
    [SerializeField] GameObject JuliusRotationObject;
    [SerializeField] TrailRenderer dashTrail;
    [SerializeField] Text comboUI;
    [SerializeField] AudioSource juliusAudioSource;
    [SerializeField] AudioClip[] swordSounds;
    [SerializeField] AudioClip heavySwordSound;
    
    
    private void Update()
    {
        if (!JuliusRB.GetComponent<HealthController>().isDead)
        {
            DetectAttackInput();
            ComboAndModifierManager();

            if (Input.GetKey(KeyCode.Space))
            {
                heavyAttackTracker += Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                heavyAttackTracker = 0;
            }
            comboUI.text = "COMBO " + comboTracker;
        }

    }

    private void FixedUpdate()
    {
        if (!JuliusRB.GetComponent<HealthController>().isDead)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && resetDashCheck)
            {
                StartCoroutine(QuickDash());
            }
        }
    }

    void DetectAttackInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            comboTimer = .5f;
            comboTracker++;
          
            if (heavyAttackTracker > .5f)
            {
                HeavyAttack();
                damageModifier = comboTracker * damageModifierStack;
            }
            else
            {
                if (quickAttackResetCheck)
                {
                    JuliusRB.AddForce(JuliusRotationObject.transform.forward * attackDashSpeed);
                    
                    StartCoroutine(QuickAttack());
                }
            }
        }
        
    }

    void ComboAndModifierManager()
    {
        comboTimer -= Time.deltaTime;

        if (comboTracker > 6)
        {
            comboTracker = 6;
        }

        if (comboTimer < 0)
        {
            comboTimer = 0;
            comboTracker = 0;
        }
    }

    void HeavyAttack()
    {
        juliusAudioSource.clip = heavySwordSound;
        juliusAudioSource.Play();
        Instantiate(heavyAttackObject, attackObjectSpawnObject.transform.position,
                 Quaternion.identity, attackObjectSpawnObject.transform);
        Instantiate(heavyArtObject, artObjectSpawn.transform.position,
            artObjectSpawn.transform.rotation, artObjectSpawn.transform);

        //Initiate Bullet Time
        GameObject timeManager =  GameObject.Find("TimeManager");
        if(timeManager != null)
        {
            timeManager.GetComponent<TimeManager>().BulletTime(1f);
        }
        
    }

    IEnumerator QuickDash()
    {
        JuliusRB.AddForce(JuliusRotationObject.transform.forward * dashSpeed);
        resetDashCheck = false;
        dashTrail.emitting = true;
        heavyAttackTracker = 1;

        yield return new WaitForSeconds(dashResetTimer);

        resetDashCheck = true;
        dashTrail.emitting = false;
        heavyAttackTracker = 0;
        
    }

    IEnumerator QuickAttack()
    {
        Instantiate(attackObject, attackObjectSpawnObject.transform.position,
                    Quaternion.identity, attackObjectSpawnObject.transform);
        Instantiate(artObject, artObjectSpawn.transform.position,
            artObjectSpawn.transform.rotation, artObjectSpawn.transform);
        juliusAudioSource.clip = swordSounds[Random.Range(0, swordSounds.Length)];
        juliusAudioSource.Play();
        quickAttackResetCheck = false;
        damageModifier = 0;

        yield return new WaitForSeconds(.2f);

        quickAttackResetCheck = true;
    }
}

