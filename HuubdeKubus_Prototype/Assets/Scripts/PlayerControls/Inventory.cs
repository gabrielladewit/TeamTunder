using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory {

    public int coins, lives;
    public bool boughtHeavy;

    public Inventory(int coinInt, int livesInt, bool boughtHeavyBool)
    {
        coins = coinInt;
        lives = livesInt;
        boughtHeavy = boughtHeavyBool;
    }

}
