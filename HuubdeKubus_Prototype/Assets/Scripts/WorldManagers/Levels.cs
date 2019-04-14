using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    public int currentLevel;
    public int currentStars;
    public int currentCoins;
    public bool slerpInitiate;

    private int levelSelect;
    private int starsCollected;

    public delegate void OnLevelChangeDelegate(int value);
    public static event OnLevelChangeDelegate OnLevelChange;

    public delegate void OnStarChangeDelegate(int stars);
    public static event OnStarChangeDelegate OnStarChange;

    // Use this for initialization
    void Start () {
        starsCollected = 0;
        currentStars = 0;
        currentCoins = 0;
        slerpInitiate = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int LevelSelected
    {
        get
        {
            return levelSelect;
        }
        set
        {
            levelSelect = value;
            Debug.Log("levelselected: " + levelSelect);

            OnLevelChange(levelSelect);
        }
    }

    public int StarsCollected
    {
        get
        {
            return starsCollected;
        }
        set
        {
            starsCollected = value;
            //OnStarChange(starsCollected);
        }
    }

    public void Reset()
    {
        currentStars = 0;
        currentCoins = 0;
        starsCollected = 0;
    }
}
