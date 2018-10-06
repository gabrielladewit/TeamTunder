using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour {

    private Rigidbody rigid;
    public float velocityLimit = 8f;

	// Use this for initialization
	void Start () {
        rigid = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rigid.velocity.magnitude > velocityLimit)
        {
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, velocityLimit);
        }
	}

    public void SetVelocityLimit(float vLimit)
    {
        velocityLimit = vLimit;
    }

    public float GetVelocityLimit()
    {
        return velocityLimit;
    }
}
