using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUIManager : MonoBehaviour {

    SaveLevelScore starsContainer;

	// Use this for initialization
	void Start () {
        starsContainer = this.gameObject.GetComponent<SaveLevelScore>();

        foreach (int x in starsContainer.stars)
        {
            Debug.Log("-------");
            GameObject starDaddy = GameObject.Find("Level" + x);

            // SET AMOUNT OF STARS FOR EACH LEVEL

            //Debug.Log(starDaddy.transform.GetChild(1));
            //starsContainer.stars[x];
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
