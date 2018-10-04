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
        StartCoroutine(DoUpdate());         // Start the coroutine function DoUpdate()
    }

    IEnumerator DoUpdate()                  // The coroutine (returns IEnumerator)
    {
        while (true)
        {
            var score = (int)Vector3.Distance(playerObj.transform.position, topObj.transform.position);
            theScore.GetComponent<Text>().text = (-8 + score).ToString();
            yield return new WaitForSeconds(0.4f);
        }
    }

}



