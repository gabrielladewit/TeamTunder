using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public bool isPaused;                               //Boolean to check if the game is paused or not

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TutorialPause()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);

        Time.timeScale = 0;
    }
}
