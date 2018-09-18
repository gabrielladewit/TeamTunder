using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour {

    public bool isFlat = true;
    private Rigidbody rigid;
    Vector3 accel;
    private GyroCalibrator gyroCalib;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        accel = new Vector3(0,0,0);
        gyroCalib = GameObject.Find("Stored").GetComponent<GyroCalibrator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        
        if (isFlat)
            tilt = Quaternion.Euler(45, 0, 0) * tilt * Time.deltaTime * 100;
        tilt.x = Mathf.Ceil(tilt.x);
        tilt.y = Mathf.Ceil(tilt.y);
        tilt.z = Mathf.Ceil(tilt.z);

        rigid.AddForce(tilt);
    }
}
