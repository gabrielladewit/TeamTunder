using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour {

    GameObject playerObj;

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, -10F, 0);
        playerObj = GameObject.Find("PlayerSphere");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == playerObj)
        {
            Physics.gravity = new Vector3(0, -5F, 0);
            playerObj.GetComponent<Rigidbody>().velocity = new Vector3(0, -3f, 0);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == playerObj)
        {
            Physics.gravity = new Vector3(0, -10F, 0);

        }
    }
}
