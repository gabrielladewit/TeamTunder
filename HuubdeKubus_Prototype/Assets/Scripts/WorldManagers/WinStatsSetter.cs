﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStatsSetter : MonoBehaviour {

    Levels currentLevel;
    Transform starDaddy, coinDaddy;

    public int level, stars, coins;

    SaveLevelScore saveStars;
    SaveInventory saveInv;

    public GameObject UI;

	// Use this for initialization
	void Start () {
        if (UI != null)
        {
            currentLevel = UI.GetComponent<Levels>();
            saveStars = UI.GetComponent<SaveLevelScore>();
            saveInv = UI.GetComponent<SaveInventory>();

            level = currentLevel.currentLevel;
            stars = currentLevel.currentStars;
            coins = currentLevel.currentCoins;
        }

        starDaddy = this.transform.GetChild(0);
        coinDaddy = this.transform.GetChild(1);

        // Set stars UI
        if (starDaddy != null)
        {
            Transform star1 = starDaddy.GetChild(0);
            star1.gameObject.SetActive(false);
            Transform star2 = starDaddy.GetChild(1);
            star2.gameObject.SetActive(false);
            Transform star3 = starDaddy.GetChild(2);
            star3.gameObject.SetActive(false);

            switch (stars)
            {
                case 1:
                    star1.gameObject.SetActive(true);
                    break;
                case 2:
                    star1.gameObject.SetActive(true);
                    star2.gameObject.SetActive(true);
                    break;
                case 3:
                    star1.gameObject.SetActive(true);
                    star2.gameObject.SetActive(true);
                    star3.gameObject.SetActive(true);
                    break;
            }
        }

        // Set bonus coins UI
        if (coinDaddy != null)
        {
            int realScore = stars * 100 + coins -100;
            coinDaddy.GetComponent<Text>().text = realScore.ToString();
            if (currentLevel.currentLevel == 1)
                MainMenuEvents.AddScoreToLeaderboard("CgkIxPu6y84TEAIQAg", realScore);
            if (currentLevel.currentLevel == 4)
                MainMenuEvents.AddScoreToLeaderboard("CgkIxPu6y84TEAIQAw", realScore);
        }

        Debug.Log("currentcoins = " + coins + ", currentstars = " + stars);


        // Save the score to your phone
        saveStars.SetLevelStars(level, stars);
        saveInv.AddCoins(coins);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
