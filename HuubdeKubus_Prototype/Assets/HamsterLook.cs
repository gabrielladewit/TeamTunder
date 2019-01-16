using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterLook : MonoBehaviour {

    public Camera cam;

    // Update is called once per frame
    void Update () {
        this.transform.LookAt(new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 15f));
	}
}
