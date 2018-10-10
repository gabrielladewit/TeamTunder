using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStay : MonoBehaviour {

    private Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 vel = new Vector3(0,0.125f,0);
    Vector3 offset;
    Vector3 startPos;

	// Use this for initialization
	void Start () {
        target = GameObject.Find ("PlayerSphere").transform;
        startPos = this.transform.position;
        offset = new Vector3 (0, 13.15f, -27f);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3 (startPos.x,this.transform.position.y,this.transform.position.z);
	}

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        //transform.position = Vector3.SmoothDamp (transform.position, desiredPosition, vel,0.5f);
        transform.position = smoothedPosition;
        transform.LookAt (target);
    }
}
