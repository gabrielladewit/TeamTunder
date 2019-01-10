using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubBehaviour : MonoBehaviour {
    Pause pause;
    Vector3 startPos;
    GameObject playerObj, camCtrl;
    public float speed;
    public float dist, xDist;
    public float realSpeed, xSpeed;

    // Use this for initialization
    void Start () {
        speed = 8;
        pause = GameObject.Find("UI").GetComponent<Pause>();
        startPos = this.transform.position;
        playerObj = GameObject.Find("PlayerSphere");
        camCtrl = GameObject.Find("Main Camera Parent");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null && !pause.isPaused  && camCtrl.GetComponent<CameraBehaviour>().initiated)
        {
            dist = Mathf.Abs((playerObj.transform.position - this.transform.position).y ); 

            if (dist > 12)
                realSpeed = speed + (dist * 0.1f);
            else
                realSpeed = speed;


            xDist = playerObj.transform.position.x - this.transform.position.x;

            if (xDist > 1)
                xSpeed = 4;
            else if (xDist < -1)
                xSpeed = -4;
            else
                xSpeed = 0;

            transform.Translate (new Vector3 (Time.deltaTime * xSpeed, Time.deltaTime * -realSpeed, 0));
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
