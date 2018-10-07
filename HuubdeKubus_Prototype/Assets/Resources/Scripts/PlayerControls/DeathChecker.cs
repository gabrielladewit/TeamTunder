using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour {
    Pause pause;
   	// Use this for initialization
	void Start () {
        if (GameObject.Find("UI") != null)
            pause = GameObject.Find("UI").GetComponent<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnBecameInvisible()
    {
        pause.DoDie();
    }
}
