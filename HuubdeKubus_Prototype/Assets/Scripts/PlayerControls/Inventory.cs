using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory {

    public int money, lives;
    public bool boughtHeavy;

    public Inventory(int moneyInt, int livesInt, bool boughtHeavyBool)
    {
        money = moneyInt;
        lives = livesInt;
        boughtHeavy = boughtHeavyBool;
    }

}
