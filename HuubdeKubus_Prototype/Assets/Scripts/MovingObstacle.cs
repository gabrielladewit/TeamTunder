﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObstacle : MonoBehaviour {
    private List<Vector3> positions = new List<Vector3>();
    Transform[] places;
    Vector3 nextPos;
    Vector3 startPos;
    Vector3 nextPosY;
    Vector3 rotate;
    float distance;
    int nextLocation = 0;
    public float speed = 0.06f;
    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        places = GetComponentsInChildren<Transform>();

        foreach (Transform go in places)
        {
            if (go.position != startPos && go.name.Contains("GameObject"))
                positions.Add(go.position);
        }
        nextPos = positions[nextLocation];
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(this.transform.position, nextPos);
        this.transform.position = Vector3.MoveTowards(transform.position, nextPos, speed);

        if (distance < 0.75f)
        {
            nextLocation++;
            if (nextLocation >= transform.childCount)
                nextLocation = 0;
            nextPos = positions[nextLocation];
        }
        transform.LookAt(nextPos);
        transform.rotation = Quaternion.Normalize(transform.rotation);
    }
}
