﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour {
    Pause pause;
   	// Use this for initialization
	void Start () {
        pause = GameObject.Find("UI").GetComponent<Pause>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnBecameInvisible()
    {
        //this.gameObject.name = "Kippen";


        if (GameObject.Find("PlayerSphere") == null)
        {
            pause.DoDie();
        }

        //Destroy(this.gameObject);
        //Application.Quit();
    }
}