using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMover : MonoBehaviour {

    private GameObject theCanvas;

	// Use this for initialization
	void Start () {
        if(GameObject.Find ("OldRuntimeCanvas") != null)
            Destroy(GameObject.Find ("OldRuntimeCanvas").gameObject);
        
        theCanvas = GameObject.Find("RuntimeCanvas");
        theCanvas.gameObject.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        theCanvas.name = "OldRuntimeCanvas";
        theCanvas.transform.SetAsFirstSibling ();
        //GameObject.Find("PausePanel").gameObject.transform.parent = GameObject.Find("UI").gameObject.transform;
        //GameObject.Find("DeathPanel").gameObject.transform.parent = GameObject.Find("UI").gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
