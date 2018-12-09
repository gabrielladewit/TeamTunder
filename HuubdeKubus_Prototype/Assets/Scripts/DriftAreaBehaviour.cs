﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftAreaBehaviour : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
