using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour {

    Pause pause;

    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerSphere")
        {
            Debug.Log("Game Won!");
        }
    }
}