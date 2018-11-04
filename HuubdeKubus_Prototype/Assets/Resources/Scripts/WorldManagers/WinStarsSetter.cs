using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStarsSetter : MonoBehaviour {

    Levels currentLevel;
    Transform starDaddy;

	// Use this for initialization
	void Start () {
        currentLevel = GameObject.Find("UI").GetComponent<Levels>();

        starDaddy = this.transform.GetChild(1);

        Transform star1 = starDaddy.GetChild(0);
        star1.gameObject.SetActive(false);
        Transform star2 = starDaddy.GetChild(1);
        star2.gameObject.SetActive(false);
        Transform star3 = starDaddy.GetChild(2);
        star3.gameObject.SetActive(false);

        switch (currentLevel.currentStars)
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
