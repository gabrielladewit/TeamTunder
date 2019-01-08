using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public enum Modes
    {
        Sway,
        Strafe
    }

    private Modes cameraMode;

    private Transform playerT;
    public float smoothSpeed = 0.125f;
    public Vector3 camPos;
    Vector3 startPos, offset;

	// Use this for initialization
	void Start () {
        cameraMode = GameObject.Find("UI").GetComponent<StartOptions>().currentCameraMode;
        playerT = GameObject.Find ("PlayerSphere").transform;
        startPos = this.transform.position;
        camPos = new Vector3 (0, -10f, -40f);
        offset = new Vector3 (0, 2f, 2f);
	}

    void FixedUpdate()
    {
        if (playerT != null)
        {
            if (cameraMode == Modes.Sway)
            {
                Vector3 camPosition = playerT.position + camPos;

                camPosition.x = 0;

                transform.LookAt(playerT);
                Quaternion camRotation = this.transform.rotation;


                if (camRotation.y > 0.1f)
                {
                    //clamp right
                    camRotation.y = 0.1f;
                }
                else if (camRotation.y < -0.1f)
                {
                    camRotation.y = -0.1f;
                    //clamp left
                }

                transform.rotation = camRotation;
                transform.position = camPosition;
            } else if (cameraMode == Modes.Strafe)
            {
                Vector3 camPosition = playerT.position + camPos;

                if (camPosition.x > 60f)
                {
                    camPosition.x = 60f;
                }
                else if (camPosition.x < -60f)
                {
                    camPosition.x = -60f;
                }

                transform.position = camPosition;
                transform.LookAt(playerT);
            }
        }
    }
}