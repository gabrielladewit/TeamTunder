using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theObj, playerObj, topObj, cameraObj;
    private Pause pause;
    float gameSpeed = 0.075f;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerSphere");
        topObj = GameObject.Find("Top");
        cameraObj = GameObject.Find("Main Camera");
        theObj = this.gameObject;
        pause = GameObject.Find("UI").GetComponent<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
        // Move the world
        float realSpeed = gameSpeed + ((int)Vector3.Distance(cameraObj.transform.position, topObj.transform.position) * 0.0001f);

        if (realSpeed >= 0.125f)
            realSpeed = 0.125f;

        //Debug.Log(realSpeed);

        if (pause != null)
        {
            if (!pause.isPaused)
            {
                theObj.transform.Translate(new Vector3(0, -realSpeed, 0));
            }
        }
        else
        {
            theObj.transform.Translate(new Vector3(0, -realSpeed, 0));
        }
    }
}
