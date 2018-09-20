using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    int count = 0;
    LoadTables theTable;
    Transform worldBlockParent;

    void Start()
    {
        theTable = GameObject.Find ("EventSystem").GetComponent<LoadTables> ();
        worldBlockParent = GameObject.Find("GameWorld").transform;

    }

    public void spawnPuzzle()
    {
        GameObject aTable = theTable.GetRandomTable();
        GameObject worldBlock = (GameObject)Instantiate(aTable, new Vector3(0,count*-33f,0), Quaternion.Euler(-90, 0, 0));
        worldBlock.transform.parent = worldBlockParent;
        count++;
    }


}
