using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObstacle : MonoBehaviour {
    private List<Vector3> positions = new List<Vector3>();
    Transform[] places;
    Vector3 nextPos;
    Vector3 startPos;
    float distance;
    int nextLocation = 0;
    float speed = 0.05f;
    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        places = GetComponentsInChildren<Transform>();

        foreach (Transform go in places)
        {
            if(go.position != startPos)
                positions.Add(go.position);
        }
        nextPos = positions[nextLocation];
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(this.transform.position, nextPos);
        
        this.transform.position = Vector3.MoveTowards(transform.position, nextPos,speed);

        if (distance < 0.75f)
        {
            nextLocation++;
            if (nextLocation >= transform.childCount)
                nextLocation = 0;
            nextPos = positions[nextLocation];
        }
       
	}
}
