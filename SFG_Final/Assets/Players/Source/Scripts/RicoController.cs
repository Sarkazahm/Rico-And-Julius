using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoController : MonoBehaviour {

    [SerializeField] public bool isAiming = false;
    [SerializeField] GameObject rotationObject;
    [SerializeField] Rigidbody RicoRB;

    [SerializeField] public GameObject currentGun;
    private Vector3 verticalLookDir;
    private Vector3 horizontalLookDir;

	void Update () {
        if (!RicoRB.GetComponent<HealthController>().isDead)
        {
            UpdateLookRotation();
        }
        CanHaveGunsDrawn();
	}

    void UpdateLookRotation()
    {
        if (!RicoRB.GetComponent<HealthController>().isDead)
        {
            verticalLookDir = Input.GetAxis("VerticalArrows") * transform.forward;
            horizontalLookDir = Input.GetAxis("HorizontalArrows") * transform.right;
            Vector3 lookDirectionVector = verticalLookDir + horizontalLookDir + transform.position;
            rotationObject.transform.LookAt(lookDirectionVector);

            if (Input.GetAxis("VerticalArrows") + Input.GetAxis("HorizontalArrows") == 0)
            {
                isAiming = false;
            }
            else
            {
                isAiming = true;
            }
        }

    }

    void CanHaveGunsDrawn()
    {
        if(!RicoRB.GetComponent<HealthController>().isDead)
        {
            currentGun.SetActive(true);
        }
        else
        {
            currentGun.SetActive(false);
        }
    }
}
