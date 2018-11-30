using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels : MonoBehaviour {
    
	void Start () {
        int[] totalStarsArray = gameObject.transform.parent.GetComponent<SaveLevelScore>().stars;
        int totalStars = 0;

        //Set Total Stars
        for (int i = 0; i < totalStarsArray.Length; i++)
        {
            totalStars += totalStarsArray[i];
        }

        //Check Total Stars VS Required Stars
        for (int i = 1; i < GameObject.Find("LevelOptions").transform.childCount; i++)
        {
            string levelName = "Level" + i;
            GameObject starDaddy = GameObject.Find(levelName);
            //Since GameObjects stars active check if it needs to be set to Deactive
            if (starDaddy != null)
            {
                if (starDaddy.GetComponent<UnlockLevelWithStars>().requiredStars > totalStars)
                {
                    starDaddy.SetActive(false);
                }
            }
        }
	}
}


