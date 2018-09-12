using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theWorld;

	// Use this for initialization
	void Start () {
        theWorld = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        theWorld.transform.Translate(new Vector3(0,0,0.15f));
	}
}
