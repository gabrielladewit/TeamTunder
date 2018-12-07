using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour {

    private float speedRotate = 5;
    public bool left = false;
	// Update is called once per frame
	void Update () {
        if(!left)
            this.gameObject.transform.Rotate(0, speedRotate * 10 * Time.deltaTime, 0);
        else
            this.gameObject.transform.Rotate(0, speedRotate * -10 * Time.deltaTime, 0);
    }
}