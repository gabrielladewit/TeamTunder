﻿using System.Collections;
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
        Vector3 tilt = Input.acceleration;


        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt * Time.deltaTime * 1000;

        rigid.AddForce(tilt);
    }
}
