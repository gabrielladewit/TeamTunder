using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour {

    public Text progressText;
    public Text coinText;
	// Use this for initialization
	void Start () {
        
	}

    private void OnEnable()
    {
        float progress = GameObject.Find("PlayerSlider").GetComponent<Slider>().value * 100;
        progressText.text = "" + (int)progress + "%";
        int coins = 0; // get amount of coins earned in game
        coinText.text = "" + coins; 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
