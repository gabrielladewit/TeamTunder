using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCombine : MonoBehaviour {

    private Rigidbody rigid;

    // Use this for initialization
    void Start () {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
