using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {
    GameObject theObj;
    private Pause pause;
    public float gameSpeed = 0.10f;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        theObj = this.gameObject;
        pause = GameObject.Find("UI").GetComponent<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
        // Move the world


        if (!pause.isPaused) {
            theObj.transform.Translate(new Vector3(0, -gameSpeed, 0));
        }
    }
}
