using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    public int currentLevel;
    public int currentStars;
    public int currentCoins;

    // Use this for initialization
    void Start () {
        currentStars = 0;
        currentCoins = 0;
    }

    public void Reset()
    {
        currentStars = 0;
        currentCoins = 0;
    }
}
