using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    
    public float horizontalSpeed;
    public float verticalSpeed = 1;
    public float amplitude = 0.5f;
    private Vector3 tempPosition;
    // Use this for initialization
    void Start()
    {
        tempPosition = transform.position;
        Debug.Log("x: " + tempPosition.x + " y: " + tempPosition.y + " z: " + tempPosition.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + 4;
        transform.position = tempPosition;

        Debug.Log("x: " + tempPosition.x + " y: " + tempPosition.y + " z: " + tempPosition.z);
        Debug.Log("/////////////////////////////");
        Debug.Log("x: " + transform.position.x + " y: " + transform.position.y + " z: " + transform.position.z);
    }
}
