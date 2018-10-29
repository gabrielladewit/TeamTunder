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
        camPos = new Vector3 (0, 0f, -25f);
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
            Vector3 dPosition = playerT.position + camPos;
            
            dPosition.x = 0;

            transform.LookAt(playerT);
            Quaternion camRotation = this.transform.rotation;
            Debug.Log(camRotation);

            if (camRotation.y > 0.1f)
            {
                Debug.Log("clamping right");
                //clamp right
                camRotation.y = 0.1f;
            } else if (camRotation.y < -0.1f)
            {
                camRotation.y = -0.1f;
                //clamp left
            }

            this.transform.rotation = camRotation;

            float angle = Vector3.Angle(dPosition, this.transform.position);
            //Debug.Log("Camera angle = " + angle);

            transform.position = dPosition;
        }
    }
}