using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour {

    private Rigidbody rigid;
    public float velocityLimit = 11f;

	// Use this for initialization
	void Start () {
        rigid = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rigid.velocity.magnitude > velocityLimit)
        {
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, velocityLimit);
        }
	}

    public void SetVelocityLimit(float vLimit)
    {
        //current limit != new limit
        if(velocityLimit - vLimit < 0)
        {
            //Smooth vLimit up with coroutine
            StartCoroutine(SmoothVelocityIncrease(vLimit));
        } else if (velocityLimit - vLimit > 0)
        {
            //Smooth vLimit down with coroutine
            StartCoroutine(SmoothVelocityDecrease(vLimit));
        }
    }

    public float GetVelocityLimit()
    {
        return velocityLimit;
    }

    IEnumerator SmoothVelocityIncrease(float newVelocity)
    {
        while (newVelocity > velocityLimit) {
            Debug.Log("INCREASING!");
            velocityLimit += 0.1f;
            yield return new WaitForFixedUpdate();
        }
        StopCoroutine("SmoothVelocityChange");
    }

    IEnumerator SmoothVelocityDecrease(float newVelocity)
    {
        while (newVelocity < velocityLimit)
        {
            Debug.Log("DECREASING!");
            velocityLimit -= 0.1f;
            yield return new WaitForFixedUpdate();
        }
        StopCoroutine("SmoothVelocityChange");
    }
}
