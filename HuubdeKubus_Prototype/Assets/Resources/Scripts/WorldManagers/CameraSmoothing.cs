using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour {
    public GameObject playerSphere, mainCamera;
    private Rigidbody playerBody;
    private VelocityLimiter vLimit;

	// Use this for initialization
	void Start () {
        playerBody = playerSphere.GetComponent<Rigidbody>();
        vLimit = playerSphere.GetComponent<VelocityLimiter>();
        StartCoroutine(UpdatePlayerSpeed());
	}
	
	// Update is called once per frame
	IEnumerator UpdatePlayerSpeed () {
        while (true)
        {
            float distance = this.transform.position.y - playerSphere.transform.position.y;

            if (distance > 8)
            {
                // MOVE FASTER -- THE BALL IS QUICKER THAN THE CAMERA
                //Debug.Log("CAM = BELOW THE BALL");
                // set velocitylimit to 10;
                vLimit.SetVelocityLimit(6);
                this.transform.Translate(new Vector3(0, -0.15f, 0));
            }
            else if (distance < -8)
            {
                // MOVE SLOWER (?)
                //Debug.Log("CAM = ABOVE THE BALL");
                // Set velocitylimit to 6;
                vLimit.SetVelocityLimit(11);
                this.transform.Translate(new Vector3(0, -0.1f, 0));
            }
            else
            {
                // JUST MOVE -- CAMERA IS IN THE MIDDLE
                vLimit.SetVelocityLimit(8);
                this.transform.Translate(new Vector3(0, -0.125f, 0));
            }

            yield return new WaitForFixedUpdate();
        }
	}
}
