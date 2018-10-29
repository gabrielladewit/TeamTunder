using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private float raycastLength = 0.55f;
    Vector3 originPos;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        originPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Ray rayLeft = new Ray(originPos, Vector3.left);
        Ray rayRight = new Ray(originPos, Vector3.right);

        Debug.DrawRay(transform.position, Vector3.right * raycastLength);

        if (Physics.Raycast(rayLeft, out hit, raycastLength) || Physics.Raycast(rayRight, out hit, raycastLength)) 
        {
            if (hit.collider.tag == "Wall")
            {
                Vector3 rigidbodyVelocity = rb.velocity;
                rigidbodyVelocity.y = -15;
                rb.velocity = rigidbodyVelocity;
            }
        }
    }
}
