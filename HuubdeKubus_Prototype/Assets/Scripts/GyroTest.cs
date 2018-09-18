using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour {

    public bool isFlat = true;
    private Rigidbody rigid;
    Vector3 accel;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
            rigid.AddForce(movement * 1000 * Time.deltaTime);
        }

        Vector3 tilt = Input.acceleration;


        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt * Time.deltaTime * 1000;

        rigid.AddForce(tilt);
    }
}
