using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUIManager : MonoBehaviour {
    
    public int[] starsArray;
    int totalStars = 0;
    public GameObject UI;

    // Use this for initialization
    void Awake () {
        starsArray = UI.GetComponent<SaveLevelScore>().stars;
        SetStarUI();
    }

    public void SetStarUI()
    {
        for (int i = 0; i < starsArray.Length; i++)
        {
            totalStars += starsArray[i];
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject starDaddy = gameObject.transform.GetChild(i).gameObject;
            //Since GameObjects stars active check if it needs to be set to Deactive
            if (starDaddy != null && starDaddy.name != "Return" && starDaddy.name != "RawImage")
            {
                Transform star1 = starDaddy.transform.GetChild(1);
                star1.gameObject.SetActive(false);
                Transform star2 = starDaddy.transform.GetChild(2);
                star2.gameObject.SetActive(false);
                Transform star3 = starDaddy.transform.GetChild(3);
                star3.gameObject.SetActive(false);

                if (starDaddy.GetComponent<UnlockLevelWithStars>().requiredStars > totalStars)
                {
                    //starDaddy.SetActive(false);
                    starDaddy.transform.GetChild(0).GetComponent<Button>().enabled = false;
                    starDaddy.transform.GetChild(0).GetComponent<Image>().color = new Color32(40,40,40,200);
                }
                else
                {
                    

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
}
