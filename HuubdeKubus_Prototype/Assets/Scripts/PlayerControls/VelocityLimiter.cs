using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{

    private Rigidbody rigid;
    public GameObject mainCamera;
    public float velocityLimit = 15f;
    public float gravity = 0.4f;
    RaycastHit hit;
    bool initiated;

    // Use this for initialization
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        CameraManager.initiateGame += CameraInitiated;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = this.transform.position.y - mainCamera.transform.position.y;
        
        //If the player is already at the bottom
        if (dist > -6 && initiated)
        {
            // IF Speed > Speedlimit
            /*if (Mathf.Abs(rigid.velocity.y) > velocityLimit)
            {
                //Lower Speed to standard
                Vector3 rigidbodyVelocity = rigid.velocity;
                rigidbodyVelocity.y = -velocityLimit;
                rigid.velocity = rigidbodyVelocity;
            }
            else*/
            rigid.AddForce(new Vector3(0,-gravity,1));
            //rigid.AddTorque();

            if ((Mathf.Abs(rigid.velocity.y) < velocityLimit))
            {
                //Else keep going faster
                Vector3 rigidbodyVelocity = rigid.velocity;
                rigidbodyVelocity.y = rigidbodyVelocity.y - gravity;
                rigid.velocity = rigidbodyVelocity;
            }
        }
    }

    public void SetVelocityLimit(float vLimit)
    {
        //current limit != new limit
        if (velocityLimit - vLimit < 0)
        {
            //Smooth vLimit up with coroutine
            StartCoroutine(SmoothVelocityIncrease(vLimit));
        }
        else if (velocityLimit - vLimit > 0)
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
        while (newVelocity > velocityLimit)
        {
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

    void CameraInitiated()
    {
        initiated = true;
    }

    private void OnDisable()
    {
        CameraManager.initiateGame -= CameraInitiated;
    }
}
