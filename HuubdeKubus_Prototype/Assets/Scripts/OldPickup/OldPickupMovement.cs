using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPickupMovement : MonoBehaviour
{
    public float verticalSpeed = 4;
    public float amplitude = 0.05f;
    public float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime *30);
        transform.position = transform.position + new Vector3(0.0f, 0.0f, Mathf.Sin(Time.realtimeSinceStartup * Time.deltaTime *verticalSpeed *30) * amplitude);
    }
}
