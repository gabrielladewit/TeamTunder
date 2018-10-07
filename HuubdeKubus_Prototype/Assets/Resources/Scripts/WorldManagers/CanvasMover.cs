using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMover : MonoBehaviour {

    private GameObject theCanvas;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("UI") != null)
        {
            theCanvas = GameObject.Find("RuntimeCanvas");
            theCanvas.gameObject.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
