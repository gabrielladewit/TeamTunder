using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
    // Using same speed reference in both, desktop and other devices
    private float speed =1000;
    private Rigidbody rb;
    void Main ()
    {
        rb = this.GetComponent<Rigidbody> ();
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
    }


    void FixedUpdate ()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        { 
            // Player movement in desktop devices
            // Definition of force vector X and Y components
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // Building of force vector
            Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
            // Adding force to rigidbody
            rb.AddForce(movement * speed * Time.deltaTime);
        }
        else
        {
            // Player movement in mobile devices
            // Building of force vector 
            Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
            // Adding force to rigidbody
            rb.AddForce(movement * speed * Time.deltaTime);
        }


    }


}