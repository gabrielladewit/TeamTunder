using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    int count = 0;
    public Levels levelManager;
    LoadTables theTable;
    Transform worldBlockParent;

    StartOptions theLevel;

    void Start ()
    {
        theTable = GameObject.Find ("EventSystem").GetComponent<LoadTables> ();
        levelManager = GameObject.Find ("UI").GetComponentInChildren<Levels> ();
        worldBlockParent = GameObject.Find ("GameWorld").transform;
    }


//    public void spawnPuzzle (int x)
//    {
//        GameObject aTable = theTable.LoadLevel (x);
//        GameObject worldBlock = (GameObject)Instantiate (aTable, new Vector3 (0, count * -33f, 0), Quaternion.Euler (-90, 0, 0));
//        worldBlock.transform.parent = worldBlockParent;
//        count++;
//    }

}
