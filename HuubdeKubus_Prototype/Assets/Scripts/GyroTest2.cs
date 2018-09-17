using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroTest2 : MonoBehaviour {

    private GameObject score;
    private Text text;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score");
        text = score.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tilt = Input.acceleration;

        tilt = Quaternion.Euler(90,0,0) * tilt;
        tilt.z = 0;

        string theT = "";

        if (tilt.x > 0)
        {
            theT = "RIGHT";
        }

        if (tilt.x <= 0)
        {
            theT = "LEFT";
        }

        if (tilt.y > 0)
        {
            theT += "UP";
        }

        if (tilt.y <= 0)
        {
            theT += "DOWN";
        }

        text.text = theT;
    }
}
