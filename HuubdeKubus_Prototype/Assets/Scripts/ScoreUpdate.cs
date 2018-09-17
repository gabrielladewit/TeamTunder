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
        StartCoroutine("DoUpdate");
    }

    IEnumerator DoUpdate()
    {
        while(true)
        {
            var score = (int)Vector3.Distance(playerObj.transform.position, topObj.transform.position);
            theScore.GetComponent<Text>().text = (-16 + score).ToString();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
