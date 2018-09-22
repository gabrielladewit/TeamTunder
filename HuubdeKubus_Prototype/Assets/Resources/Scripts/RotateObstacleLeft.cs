using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacleLeft : MonoBehaviour
{
    private float speedRotate = 5;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, speedRotate * -10 * Time.deltaTime, 0);
    }
}