using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStatsSetter : MonoBehaviour {

    Levels currentLevel;
    Transform starDaddy, coinDaddy;

    public int stars, coins;

    SaveLevelScore saveStars;
    SaveInventory saveInv;

	// Use this for initialization
	void Start () {
        GameObject UI = GameObject.Find("UI");
        currentLevel = UI.GetComponent<Levels>();
        saveStars = UI.GetComponent<SaveLevelScore>();
        saveInv = UI.GetComponent<SaveInventory>();

        stars = currentLevel.currentStars;
        coins = currentLevel.currentCoins;

        starDaddy = this.transform.GetChild(1);
        coinDaddy = this.transform.GetChild(2);

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

        if (coinDaddy != null)
        {
            Debug.Log("SET WIN TEXT");
            coinDaddy.GetComponent<Text>().text = coins.ToString();
        }

        Debug.Log("currentcoins = " + coins + ", currentstars = " + stars);

        saveStars.SetLevelStars();
        saveInv.AddCoins(coins);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
