using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theObj, playerObj, topObj;
    private Pause pause;
    public float gameSpeed = 0.10f;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerSphere");
        topObj = GameObject.Find("Top");
        theObj = this.gameObject;
        pause = GameObject.Find("UI").GetComponent<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
        // Move the world


        if (pause != null)
        {
            if (!pause.isPaused)
            {
                float realSpeed = gameSpeed * ((int)Vector3.Distance(playerObj.transform.position, topObj.transform.position) * 0.01f);
                //Debug.Log(realSpeed);
                theObj.transform.Translate(new Vector3(0, -realSpeed, 0));
            }
        }
        else
        {
            float realSpeed = gameSpeed * ((int)Vector3.Distance(playerObj.transform.position, topObj.transform.position) * 0.01f);
           // Debug.Log(realSpeed);
            theObj.transform.Translate(new Vector3(0, -realSpeed, 0));
        }
    }
}
