using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubAnimationEvent : MonoBehaviour {

    public bool isCatched = false;

    public void PlayerCatched() {
        isCatched = true;
    }
}
