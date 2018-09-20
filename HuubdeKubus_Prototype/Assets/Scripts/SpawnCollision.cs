using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollision : MonoBehaviour {

    static GameObject playerObj;
    static WorldGeneration worldGen;
    bool triggered = false;

    // Use this for initialization
    void Start () {
        playerObj = GameObject.Find("PlayerSphere");
        worldGen = GameObject.Find ("GameWorld").GetComponent<WorldGeneration>();
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject == playerObj && !triggered)
        {
            triggered = true;
            worldGen.spawnPuzzle ();
            Destroy(this);
        }
    }
}
