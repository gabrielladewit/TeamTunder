using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubBehaviour : MonoBehaviour {
    Pause pause;
    Vector3 startPos;
    GameObject playerObj;
    float gameSpeed = 0.18f;

	// Use this for initialization
	void Start () {
        pause = GameObject.Find("UI").GetComponent<Pause>();
        startPos = this.transform.position;
        playerObj = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null && !pause.isPaused)
        {
            float realSpeed = gameSpeed + ((int)Vector3.Distance (playerObj.transform.position, startPos) * 0.0001f);

            if (realSpeed >= 0.1f)
                realSpeed = 0.1f;

//            Debug.Log (realSpeed);

            transform.Translate (new Vector3 (0, -realSpeed, 0));
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == playerObj)
        {
            pause.DoDie ();
        }
    }
}
