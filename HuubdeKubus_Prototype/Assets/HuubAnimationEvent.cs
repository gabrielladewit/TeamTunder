using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubAnimationEvent : MonoBehaviour {

    Pause pause;

    public void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

    public void PlayerCatched() {
        pause.DoDie();
    }
}
