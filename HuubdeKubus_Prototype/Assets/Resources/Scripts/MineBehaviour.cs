﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {

    public GameObject player;
    public float force, addRadius, delay;

    float radius, tempDelay;
    bool onOff;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerSphere");
        radius = this.gameObject.GetComponent<SphereCollider>().radius;
        tempDelay = delay;
    }

    void Update()
    {
        if (onOff)
        {
            tempDelay -= 2f * Time.deltaTime;

            if (tempDelay <= 0.0f)
            {
                Rigidbody rb = player.GetComponent<Rigidbody>();
                rb.AddExplosionForce(force * 10, this.transform.position, addRadius + radius);
                onOff = false;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        onOff = true;
        tempDelay = delay;
    }
}
