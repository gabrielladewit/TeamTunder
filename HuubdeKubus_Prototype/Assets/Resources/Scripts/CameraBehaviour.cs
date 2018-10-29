using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    private Transform playerT;
    public float smoothSpeed = 0.125f;
    public Vector3 camPos;
    Vector3 startPos, offset;

	// Use this for initialization
	void Start () {
        playerT = GameObject.Find ("PlayerSphere").transform;
        startPos = this.transform.position;
        camPos = new Vector3 (0, 2f, -20f);
        offset = new Vector3 (0, 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = new Vector3 (startPos.x,this.transform.position.y,this.transform.position.z);
	}

    void FixedUpdate()
    {
        if (playerT != null)
        {
            Vector3 desiredPosition = playerT.position + camPos;
            desiredPosition.x = 0;
            Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
            transform.LookAt (playerT);
        }
    }
}
