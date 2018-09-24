using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRemover : MonoBehaviour {

    GameObject playerObj;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null && Vector3.Distance(playerObj.transform.position, this.transform.position) > 150)
        {
            Destroy(this.gameObject);
        }
	}
}
