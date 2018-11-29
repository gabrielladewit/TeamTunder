﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUIManager : MonoBehaviour {

    SaveLevelScore starsContainer;
    int[] starsArray;

	// Use this for initialization
	void Awake () {
        starsContainer = this.gameObject.GetComponent<SaveLevelScore>();
    }

    void Update()
    {
        if (starsContainer != null)
        {
            if (starsContainer.initialized)
            {
                starsArray = starsContainer.GetStars();
                Debug.Log("Star array length = " + starsArray.Length);
                starsContainer = null;
                SetStarUI();
            }
        }
    }

    public void SetStarUI()
    {
        for (int i = 1; i <= starsArray.Length; i++)
        {
            GameObject starDaddy = GameObject.Find("Level" + i);

            if (starDaddy != null)
            {
                Transform star1 = starDaddy.transform.GetChild(1);
                Debug.Log("star 1 name = " + star1.name);
                star1.gameObject.SetActive(false);
                Transform star2 = starDaddy.transform.GetChild(2);
                star2.gameObject.SetActive(false);
                Transform star3 = starDaddy.transform.GetChild(3);
                star3.gameObject.SetActive(false);

                switch (starsArray[i])
                {
                    case 0:
                        break;
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
        }
    }
}
