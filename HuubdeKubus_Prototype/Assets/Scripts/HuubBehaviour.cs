using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubBehaviour : MonoBehaviour {
    Pause pause;
    Vector3 startPos;
    GameObject playerObj;
    public float speed;
    public float dist;
    public float realSpeed;

    // Use this for initialization
    void Start () {
        speed = 8;
        pause = GameObject.Find("UI").GetComponent<Pause>();
        startPos = this.transform.position;
        playerObj = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null && !pause.isPaused)
        {
            dist = Mathf.Abs((playerObj.transform.position - this.transform.position).y ); 

            if (dist > 12)
                realSpeed = speed + (dist * 0.1f);
            else
                realSpeed = speed;

            transform.Translate (new Vector3 (0, Time.deltaTime * -realSpeed, 0));
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
