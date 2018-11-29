using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStars : MonoBehaviour {

    public GameObject Star0;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public Levels levelScript;
    public int starsToDisplay;

    // Use this for initialization
    void Start () {
        levelScript = GameObject.Find("UI").GetComponent<Levels>();
        ChangeStars();
    }

    public void ChangeStars()
    {
        //Get the amount of stars of the current level and display them
        starsToDisplay = levelScript.starlvlarray[levelScript.currentLevel];

        switch (starsToDisplay)
        {
            case 0:
                Star0.SetActive(true);
                break;
            case 1:
                Star0.SetActive(false);
                Star1.SetActive(true);
                break;
            case 2:
                Star1.SetActive(false);
                Star2.SetActive(true);
                break;
            case 3:
                Star2.SetActive(false);
                Star3.SetActive(true);
                break;
        }
    }
}
