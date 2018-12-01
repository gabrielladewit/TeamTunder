using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour {

    Pause pause;
    ShowPanels panels;

    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
        panels = GameObject.Find("UI").GetComponent<ShowPanels>();
    }

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerSphere")
        {
            collision.gameObject.GetComponent<PlayerController>().StopStopwatch();
            pause.DoWin();
        }
    }
}