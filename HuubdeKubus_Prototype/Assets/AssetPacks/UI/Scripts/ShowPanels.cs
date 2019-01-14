using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject deathPanel;
    public GameObject winPanel;
    public GameObject levelPanel;
    public GameObject tutorialPanel;

    public GameObject textPanel;
    public GameObject textPanel1;
    public GameObject textPanel2;
    public GameObject textPanel3;

    public int next;

    //Call this function to deactivate the Welcome panel and show the Tutorial panel
    public void ShowTutorialPanel()
    {
        optionsTint.SetActive(true);

        switch (next)
        {
            case 0:
                textPanel.SetActive(true);
                break;
            case 1:
                textPanel.SetActive(false);
                textPanel1.SetActive(true);
                break;
            case 2:
                textPanel1.SetActive(false);
                textPanel2.SetActive(true);
                break;
            case 3:
                textPanel2.SetActive(false);
                textPanel3.SetActive(true);
                break;
            default:
                break;
        }
        next++;
    }

    //Call this function to deactivate the Tutorial panel
    public void HideTutorialPanel()
    {
        tutorialPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

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

    public void ShowLevels()
    {
        levelPanel.SetActive(true);
    }

    public void HideLevels()
    {
        levelPanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        //winPanel.transform.SetParent(GameObject.Find("UI").gameObject.transform);
        optionsTint.SetActive(true);
    }

    public void HideWinPanel()
    {
        winPanel.SetActive(false);
        optionsTint.SetActive(false);
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
