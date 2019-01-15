﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    GameObject theScore, playerObj, topObj, cameraObj;
    public bool multiplier = false;
    private int score;
    private float multiplierDurance;
    public float multiplierTime = 5f;

    // Use this for initialization
    void Start () {
        theScore = GameObject.Find("Score");
        playerObj = GameObject.Find("PlayerSphere");
        cameraObj = GameObject.Find("Main Camera");
        topObj = GameObject.Find("Top");
        multiplierDurance = multiplierTime;
        StartCoroutine(DoUpdate());         // Start the coroutine function DoUpdate()
    }

    IEnumerator DoUpdate()                  // The coroutine (returns IEnumerator)
    {
        while (true)
        {

            if (multiplier)
            {
                this.score = (int)(Vector3.Distance(playerObj.transform.position, topObj.transform.position) * 1.5f);
                Debug.Log("Multiplier is active");

                multiplierDurance -= Time.deltaTime*10;
//                Debug.Log("Time left: " + multiplierDurance);

                if (multiplierDurance < 0)
                {
                    this.score = (int)Vector3.Distance(playerObj.transform.position, topObj.transform.position);
                    multiplier = false;
                    multiplierDurance = multiplierTime;
                    Debug.Log("MULTIPLIER DEACTIVATED");
//                    Debug.Log("multiplier time reset: " + multiplierDurance );
                }

            }

            


            this.score = (int)Vector3.Distance(playerObj.transform.position, topObj.transform.position);

           // theScore.GetComponent<Text>().text = score.ToString();

            yield return new WaitForSeconds(0.4f);
        }
    }

}



