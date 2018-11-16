using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScene : MonoBehaviour {

    GameObject pausePanel, deathPanel;

	// Use this for initialization
	void Start () {
        GameObject pPanel = GameObject.Find("PausePanel");
        if (pPanel != null)
        {
            pPanel.SetActive(false);
        }

        GameObject dPanel = GameObject.Find("DeathPanel");
        if (dPanel != null)
        {
            dPanel.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
