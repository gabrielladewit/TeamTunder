﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    public int currentLevel;
    public int currentStars;
    public int currentCoins;
    public int currenLevelDuration;

	// Use this for initialization
	void Start () {
        currentStars = 0;
        currentCoins = 0;
        switch (currentLevel)
        {
            case 1:
                currenLevelDuration = 45;
                break;
            case 2:
                currenLevelDuration = 50;
                break;
            case 3:
                currenLevelDuration = 55;
                break;
            case 4:
                currenLevelDuration = 60;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
