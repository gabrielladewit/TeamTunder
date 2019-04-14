﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour { 


	private ShowPanels showPanels;						//Reference to the ShowPanels script used to hide and show UI panels
	public bool isPaused, isDead;						//Boolean to check if the game is paused or not
	private StartOptions startScript;                   //Reference to the StartButton script
    bool showedTutorial = false;
    bool onClickSet = false;
	//Awake is called before Start()
	void Awake()
	{
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
		//Get a component reference to StartButton attached to this object, store in startScript variable
		startScript = GetComponent<StartOptions> ();

        //Levels.OnLevelChange += PauseTutorial;
        //CameraManager.onBoolChange += PauseTutorial;
	}

    public void setOnClick()
    {
        GameObject.Find("PauseButton").GetComponent<Button>().onClick.AddListener(DoPause);
    }

    // Update is called once per frame
    void Update () {
		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && !isPaused && !startScript.inMainMenu && !isDead) 
		{
            //Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && isPaused && !startScript.inMainMenu && !isDead) 
		{
            //Call the UnPause function to unpause the game
            UnPause ();
		}
    }

    public void DoWin()
    {
        isPaused = true;
        Time.timeScale = 0;
        showPanels.ShowWinPanel();
    }

	public void PauseTutorial(int level, bool init)
	{
        Debug.Log("pause: " + level);

        if (!showedTutorial && level == 1)
        {
            Debug.Log("after if: " + level);
            //Set isPaused to true
            isPaused = true;
            Time.timeScale = 0;
            //call the ShowPausePanel function of the ShowPanels script
            showPanels.ShowTutorialPanel();
            showedTutorial = true;
        }
    }


    public void DoPause()
    {
        if (!isPaused)
        {
            //Set isPaused to true
            isPaused = true;
            //Set time.timescale to 0, this will cause animations and physics to stop updating
            Time.timeScale = 0;
            //call the ShowPausePanel function of the ShowPanels script
            showPanels.ShowPausePanel();
        }
        else
            UnPause();
    }

    public void DoDie()
    {
        isPaused = true;
        isDead = true;
        Time.timeScale = 0;
        showPanels.ShowDeathPanel();
    }


	public void UnPause()
	{
		//Set isPaused to false
		isPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		//call the HidePausePanel function of the ShowPanels script
		showPanels.HidePausePanel ();
	}

    public void DoRestart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void DoRestartFromWin()
    {
        SceneManager.LoadScene(Application.loadedLevel);
        showPanels.HideWinPanel();
    }

    public void DoQuit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
