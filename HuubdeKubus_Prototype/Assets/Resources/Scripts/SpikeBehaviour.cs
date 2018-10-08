using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour {

    public GameObject player;
    Pause pause;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PlayerSphere");
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pause.DoDie();
        }
    }
}
