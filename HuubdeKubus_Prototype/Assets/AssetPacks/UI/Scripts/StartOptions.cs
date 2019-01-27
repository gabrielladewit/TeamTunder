using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartOptions : MonoBehaviour {

	public int sceneToStart = 1;										//Index number in build settings of scene to load if changeScenes is true
	public bool changeScenes;											//If true, load a new scene when Start is pressed, if false, fade out UI and continue in single scene
	public bool changeMusicOnStart;										//Choose whether to continue playing menu music or start a new music clip

	[HideInInspector] public bool inMainMenu = true;					//If true, pause button disabled in main menu (Cancel in input manager, default escape key)
	[HideInInspector] public Animator animColorFade; 					//Reference to animator which will fade to and from black when starting game.
	[HideInInspector] public Animator animMenuAlpha;					//Reference to animator that will fade out alpha of MenuPanel canvas group
	 public AnimationClip fadeColorAnimationClip;		                //Animation clip fading to color (black default) when changing scenes
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;		//Animation clip fading out UI elements alpha


	private PlayMusic playMusic;										//Reference to PlayMusic script
	private float fastFadeIn = .01f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
	private ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels
     MainMenuEvents mainMenuEvents;
    public Levels levelManager;
    public Pause pauseScript;
    public Tutorial tutorialScript;

    public CameraBehaviour.Modes currentCameraMode = CameraBehaviour.Modes.Sway;
	
	void Awake()
	{
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

        //Get a reference to PlayMusic attached to UI object
        playMusic = GetComponent<PlayMusic> ();

        mainMenuEvents = GameObject.Find("GooglePlayApi").GetComponent<MainMenuEvents>();
        levelManager = GetComponent<Levels>();
        pauseScript = GetComponent<Pause>();
        tutorialScript = GetComponent<Tutorial>();
	}

    public void LevelClicked(int x)
    {
        levelManager.currentLevel = x;
        ChangeScenes();
    }

    public void ChangeScenes()
    {
        //If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
        //To change fade time, change length of animation "FadeToColor"

        //If changeScenes is true, start fading and change scenes halfway through animation when screen is blocked by FadeImage
        if (changeScenes)
        {
            //Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
            Invoke("LoadDelayedGame", fadeColorAnimationClip.length * .5f);

            //Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
            animColorFade.SetTrigger("fade");
        }
    }

    public void StartButtonClicked()
	{
        //Hide the main menu UI element
        showPanels.HideMenu();
        showPanels.ShowLevels();
    }

    public void ReturnFromLevelSelect()
    {
        showPanels.HideLevels();
        showPanels.ShowMenu();
    }

    public void ShopButtonClicked()
    {
        //If changeScenes is true, start fading and change scenes halfway through animation when screen is blocked by FadeImage
        if (changeScenes)
        {
            //Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
            Invoke("LoadDelayedShop", fadeColorAnimationClip.length * .5f);

            //Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
            animColorFade.SetTrigger("fade");
        }
    }

    public void LeaderboardButtonClicked()
    {
        if(levelManager.currentLevel == 1)
            mainMenuEvents.showSpecificLeaderboard("CgkIxPu6y84TEAIQAg");
        if(levelManager.currentLevel == 4)
            mainMenuEvents.showSpecificLeaderboard("CgkIxPu6y84TEAIQAw");
    }

    public void MainMenuButtonClicked()
    {
        Debug.Log("Invoking main menu");
        //Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
        Invoke("LoadDelayedMainMenu", fadeColorAnimationClip.length * .0f);

        //Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
        animColorFade.SetTrigger("fade");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneWasLoaded;
    }

    //Once the level has loaded, check if we want to call PlayLevelMusic
    void SceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
		//if changeMusicOnStart is true, call the PlayLevelMusic function of playMusic
		if (changeMusicOnStart)
		{
			//playMusic.PlayLevelMusic ();
		}	
	}

    private void LoadDelayedGame()
	{
        //Pause button now works if escape is pressed since we are no longer in Main menu.
        inMainMenu = false;

		//Hide the main menu UI element
		showPanels.HideMenu ();
        showPanels.HideLevels();
        
        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene (1);
    }



    private void LoadDelayedShop()
    {
        //Pause button now works if escape is pressed since we are no longer in Main menu.
        //inMainMenu = false;

        Debug.Log("S Invoked");
        //Hide the main menu UI element
        showPanels.HideMenu();

        Debug.Log("S Scene");
        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene(2);
    }

    private void LoadDelayedMainMenu()
    {
        Destroy(this.gameObject);
        //Pause button now works if escape is pressed since we are no longer in Main menu.
        inMainMenu = false;
        
        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene(0);
    }

    public void HideDelayed()
	{
		//Hide the main menu UI element after fading out menu for start game in scene
		showPanels.HideMenu();
	}

	public void StartGameInScene()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			//Wait until game has started, then play new music
			Invoke ("PlayNewMusic", fadeAlphaAnimationClip.length);
		}
		//Set trigger for animator to start animation fading out Menu UI
		animMenuAlpha.SetTrigger ("fade");
		Invoke("HideDelayed", fadeAlphaAnimationClip.length);
		Debug.Log ("Game started in same scene! Put your game starting stuff here.");
	}

	public void PlayNewMusic()
	{
		//Fade up music nearly instantly without a click 
		playMusic.FadeUp (fastFadeIn);
		//Play music clip assigned to mainMusic in PlayMusic script
		playMusic.PlaySelectedMusic (1);
	}
    
    public void SetCameraMode()
    {
        CameraBehaviour.Modes camMode;

        switch (GameObject.Find("CameraModeOptions").GetComponent<Dropdown>().value)
        {
            case 1:
                camMode = CameraBehaviour.Modes.Sway;
                break;
            case 0:
                camMode = CameraBehaviour.Modes.Strafe;
                break;
            default:
                camMode = CameraBehaviour.Modes.Strafe;
                break;
        }

        currentCameraMode = camMode;
    }
}
