using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    public GameObject floor;
    public float speed;

    float t;
    float max;
    float min;

    void Start()
    {
        max = floor.transform.position.x + (floor.transform.localScale.x / 2);
        min = floor.transform.position.x - (floor.transform.localScale.x / 2);
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Mathf.Lerp(min, max, t), transform.position.y, transform.position.z);

        t += speed * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0.0f;
        }
        
    }
}

