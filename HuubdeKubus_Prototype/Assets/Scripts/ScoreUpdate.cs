using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    GameObject theScore, playerObj, topObj;
    public bool multiplier = false;
    private int score;

    // Use this for initialization
    void Start () {
        theScore = GameObject.Find("Score");
        playerObj = GameObject.Find("PlayerSphere");
        topObj = GameObject.Find("Top");
        StartCoroutine(DoUpdate());
        
	}

    IEnumerator DoUpdate()
    {
        while (true)
        {
            if (multiplier)
            {
                score = (int)(Vector3.Distance(playerObj.transform.position, topObj.transform.position) * 1.5f);
                Debug.Log("Multiplier is active");
            }
            else
            {
                score = (int)Vector3.Distance(playerObj.transform.position, topObj.transform.position);
            }
            
            theScore.GetComponent<Text>().text = (-16 + score).ToString();
            yield return new WaitForSeconds(0.4f);
        }
    }

}
