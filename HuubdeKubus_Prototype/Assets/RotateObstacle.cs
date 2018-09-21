using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour {

    public float speedRotate;

	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0, speedRotate * 10 * Time.deltaTime, 0);
	}
}