using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    GameObject theScore, playerObj, topObj;

	// Use this for initialization
	void Start () {
        theScore = GameObject.Find("Score");
        playerObj = GameObject.Find("PlayerSphere");
        topObj = GameObject.Find("Top");
	}
	
	// Update is called once per frame
	void Update () {
        var score = (int) Vector3.Distance(playerObj.transform.position, topObj.transform.position);
        theScore.GetComponent<Text>().text = score.ToString();

    }
}
