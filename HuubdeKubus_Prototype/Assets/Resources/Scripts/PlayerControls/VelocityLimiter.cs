using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{

    private Rigidbody rigid;
    public GameObject mainCamera;
    private float velocityLimit = 15f;
    public float gravity = 0.4f;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = this.transform.position.y - mainCamera.transform.position.y;

        Debug.Log(dist);

        //If the player is already at the bottom
        if (dist > -6)
        {
            // IF Speed > Speedlimit
            if (Mathf.Abs(rigid.velocity.y) > velocityLimit)
            {
                //Lower Speed to standard
                Vector3 rigidbodyVelocity = rigid.velocity;
                rigidbodyVelocity.y = -velocityLimit;
                rigid.velocity = rigidbodyVelocity;
            }
            else
            {
                //Else keep going faster
                Vector3 rigidbodyVelocity = rigid.velocity;
                rigidbodyVelocity.y = rigidbodyVelocity.y - gravity;
                rigid.velocity = rigidbodyVelocity;
            }


            /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, 1))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                if ((hit.distance < .6f) && (hit.collider.name != "BreakCube"))
                {
                    Vector3 rigidbodyVelocity = rigid.velocity;
                    rigidbodyVelocity.y = 0;
                    rigid.velocity = rigidbodyVelocity;
                }
            }*/
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
}
