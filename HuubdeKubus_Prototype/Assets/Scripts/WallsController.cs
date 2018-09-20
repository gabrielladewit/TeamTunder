using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour {

    Vector3 wallsBegin;
    GameObject thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = GameObject.Find("PlayerSphere");
        wallsBegin = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.x >= thePlayer.transform.position.x + 10)
        {
            GameObject.Destroy(this);
        }
    }
}
