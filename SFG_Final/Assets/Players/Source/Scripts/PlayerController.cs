using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField] Rigidbody playerRB;
    [SerializeField] GameObject rotationObject;
    [SerializeField] float speed = 3;
    [SerializeField] Vector3 lookAtTarget;
    [SerializeField] HealthController attachedHealthController;
    [SerializeField] public bool isDowned = false;
    [SerializeField] GameObject reviveVolume;
    [SerializeField] GameObject instantiatedReviveVolume;
    [SerializeField] GameObject reviveUI;

    float moveSpeed;

    [SerializeField] string horizontalAxisName = "Horizontal";
    [SerializeField] string verticalAxisName = "Vertical";

    public Vector3 playerVelocityVector;
    public bool specialFacingTracking = false;

    float horizontalMovement;
    float verticalMovement;

    private bool isInstantiated = false;
	
	void Update () {
        CalculateMovement();
	}

    private void FixedUpdate()
    {
        MoveCharacter();
        InitiateDowned();
        CheckForReviveInput();
    }

    //Functions----------------------------------------------------------------------------------------------
    void CalculateMovement()
    {
        if (!isDowned)
        {
            if (horizontalMovement != 0 && verticalMovement != 0)
            {
                moveSpeed = speed / 1.5f;
            }
            else
            {
                moveSpeed = speed;
            }
            horizontalMovement = Input.GetAxis(horizontalAxisName) * moveSpeed;
            verticalMovement = Input.GetAxis(verticalAxisName) * moveSpeed;
        }
    }
    void MoveCharacter()
    {
        if (!isDowned)
        {
            Vector3 verticalTransform = (verticalMovement * transform.forward * Time.deltaTime);
            Vector3 horizontalTransform = (horizontalMovement * transform.right * Time.deltaTime);
            playerVelocityVector = transform.position + verticalTransform + horizontalTransform;
            playerRB.MovePosition(playerVelocityVector);
            if (!specialFacingTracking)
            {
                rotationObject.transform.LookAt(playerVelocityVector);
            }
        }
    }

    void InitiateDowned()
    {
        if(attachedHealthController.isDead == true)
        {
            if(!isDowned)
            {
                playerRB.AddForce(transform.position + transform.right * 100);
                instantiatedReviveVolume = Instantiate(reviveVolume, transform.position, Quaternion.identity);
                reviveUI.SetActive(true);
                reviveUI.GetComponent<Slider>().value = 0;
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Score -= 500;
            }
            isDowned = true;
            playerRB.constraints = RigidbodyConstraints.None;
            instantiatedReviveVolume.transform.position = gameObject.transform.position;
            
        }
    }

    void CheckForReviveInput()
    {
        if(instantiatedReviveVolume!=null)
        {
            if(instantiatedReviveVolume.GetComponent<ReviveVolume>().isRevivable)
            {
                //do the thing to revive the guy
                if(Input.GetAxis("Action")!=0)
                {
                    instantiatedReviveVolume.GetComponent<ReviveVolume>().reviveProgress += Time.deltaTime;
                    reviveUI.GetComponent<Slider>().value = instantiatedReviveVolume.GetComponent<ReviveVolume>().reviveProgress;
                }
                if (instantiatedReviveVolume.GetComponent<ReviveVolume>().reviveProgress >=5)
                {
                    RevivePlayer();
                    Destroy(instantiatedReviveVolume);
                    reviveUI.SetActive(false);
                }
                
            }
        }
    }
  
    void RevivePlayer()
    {
        attachedHealthController.health = 100;
        attachedHealthController.isDead = false;
        isDowned = false;
        playerRB.transform.position = playerRB.transform.position + transform.up * 3;
        playerRB.transform.rotation = Quaternion.Euler(Vector3.zero);
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

}
