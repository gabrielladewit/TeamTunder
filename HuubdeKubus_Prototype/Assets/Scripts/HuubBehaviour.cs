﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubBehaviour : MonoBehaviour {
    Pause pause;
    Vector3 startPos;
    GameObject playerObj;
    public float speed;
    public float dist, xDist;
    public float realSpeed, xSpeed;
    public Animator ani;
    public HuubAnimationEvent aniEvent;

    // Use this for initialization
    void Start () {
        speed = 8;
        pause = GameObject.Find("UI").GetComponent<Pause>();
        startPos = this.transform.position;
        playerObj = GameObject.Find("PlayerSphere");
	}

    // Update is called once per frame
    void Update()
    {
        if (playerObj != null && !pause.isPaused)
        {
            dist = Mathf.Abs((playerObj.transform.position - this.transform.position).y);

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

            transform.Translate(new Vector3(Time.deltaTime * xSpeed, Time.deltaTime * -realSpeed, 0));
        }

        if (Vector2.Distance(new Vector2(playerObj.transform.position.x, playerObj.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 26.5f)
        {
            realSpeed = 0;
            ani.SetInteger("State", 1);
        }

        if (aniEvent.isCatched == true)
        {
            pause.DoDie();
        }

        Debug.Log(ani.GetInteger("State"));
        Debug.Log(Vector2.Distance(new Vector2(playerObj.transform.position.x, playerObj.transform.position.y), new Vector2(transform.position.x, transform.position.y)));
    }

    //void OnTriggerEnter(Collider coll)
    //{
    //    if (coll.gameObject == playerObj)
    //    {
    //        pause.DoDie ();
    //    }
    //}
}
