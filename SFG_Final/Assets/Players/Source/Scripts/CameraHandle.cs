using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour {

    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;
    [SerializeField] GameObject gameCamera;
    [SerializeField] float cameraLocal = 10f;
    [SerializeField] float cameraDistanceMin = 10f;
    [SerializeField] float cameraDistanceMax = 30f;
    [SerializeField] float cameraZoomOutRate = .8f;
	
	void Start () {
		
	}
	
	
	void Update () {
        cameraLocal = Vector3.Distance(target1.transform.position, target2.transform.position) * cameraZoomOutRate;
        if(cameraLocal < cameraDistanceMin)
        {
            cameraLocal = cameraDistanceMin;
        }
        if(cameraLocal > cameraDistanceMax)
        {
            cameraLocal = cameraDistanceMax;
        }

        gameObject.transform.position = (target1.transform.position + target2.transform.position) / 2;

        gameCamera.transform.localPosition = new Vector3(0,cameraLocal,-cameraLocal/2);
	}
}
