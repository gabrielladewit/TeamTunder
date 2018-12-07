using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsvisualtesting : MonoBehaviour {

    int coins;

	// Use this for initialization
	void Start () {
        coins = GameObject.Find("UI").GetComponent<SaveInventory>().currentMoney;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = coins.ToString();
	}
}
