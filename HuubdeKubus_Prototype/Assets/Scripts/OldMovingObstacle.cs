using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovingObstacle : MonoBehaviour {

    Vector3 pos1, pos2, nextPos;
    public float speed = 15f;
    float distance;

	// Use this for initialization
	void Start () {
        pos1 = this.transform.position;
        pos2 = this.gameObject.transform.GetChild(0).position;
        nextPos = pos2;
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);

        distance = Vector3.Distance(this.transform.position, nextPos);

        if (distance < 0.5f)
        {
            if (nextPos == pos1)
            {
                nextPos = pos2;
            }
            else
            {
                nextPos = pos1;
            }

            transform.LookAt(nextPos);
        }
    }
}
