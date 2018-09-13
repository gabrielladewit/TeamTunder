using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theWorld, theCam;
    public float gameSpeed = 0.10f;

	// Use this for initialization
	void Start () {
        theWorld = this.gameObject;
        theCam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        // Move the world
        theWorld.transform.Translate(new Vector3(0,0,gameSpeed));
        // Move the camera
        Vector3 move = Quaternion.Euler(12, 0, 0) * new Vector3(0, gameSpeed, 0) * Time.deltaTime;
        theCam.transform.Translate(move);
    }
}
