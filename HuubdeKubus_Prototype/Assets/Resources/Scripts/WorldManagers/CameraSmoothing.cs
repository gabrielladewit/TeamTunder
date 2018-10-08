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
	}

    private void Update()
    {
        this.transform.Translate(new Vector3(0, -0.125f, 0));
    }
}
