using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstraintTest : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.constraints = RigidbodyConstraints.None;
    }

    public void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
    }
}
