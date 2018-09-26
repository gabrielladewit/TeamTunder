using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theObj, playerObj, topObj;
    private Pause pause;
    public float gameSpeed = 50f;
    private bool paused = false;
    private float slowdownTimeDurance;
    public float sDTTime = 3f;
    private float baseWorldSpeed = 0.01f;

    // Use this for initialization
    void Start () {
        //playerObj = GameObject.Find("PlayerSphere");
        topObj = GameObject.Find("Top");
        theObj = this.gameObject;
        pause = GameObject.Find("UI").GetComponent<Pause>();
        slowdownTimeDurance = sDTTime;
    }

	// Update is called once per frame
	void Update () {
        // Move the world
        if (pause != null)
        {
            if (!pause.isPaused)
            {
                //float realSpeed = gameSpeed * ((int)Vector3.Distance(playerObj.transform.position, topObj.transform.position) * 0.01f);
                //Debug.Log(realSpeed);
                theObj.transform.Translate(new Vector3(0, -gameSpeed, 0));
            }
        }
    }
}
