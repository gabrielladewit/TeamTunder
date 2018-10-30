using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject deathPanel;
    public GameObject winPanel;


	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        winPanel.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        optionsTint.SetActive(true);
    }

    //Call this function to show deathpanel on death
    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
//        deathPanel.transform.SetParent(GameObject.Find("TempHolder").gameObject.transform);
        //deathPanel.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        optionsTint.SetActive(true);
    }

    //Call this function to go from death to main menu
    public void DeathToMain()
    {
        deathPanel.SetActive(false);
        optionsTint.SetActive(false);
    }
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
        //pausePanel.transform.SetParent(GameObject.Find("TempHolder").gameObject.transform);
        //pausePanel.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}
}
