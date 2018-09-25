using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    int count = 0;
    int waterCount = 0;
    int waterRnd;
    bool waterSpawning = false;
    public GameObject waterPrefab;
    public GameObject wall;
    LoadTables theTable;
    Transform worldBlockParent;

    void Start()
    {
        theTable = GameObject.Find ("EventSystem").GetComponent<LoadTables> ();
        worldBlockParent = GameObject.Find("GameWorld").transform;

    }

    void spawnWater()
    {
        waterRnd = Random.Range (0, 10);

        if (waterRnd > 7 && !waterSpawning)
        {
            waterSpawning = true;
        }

        if (waterSpawning && waterCount < 3)
        {
            GameObject water = (GameObject)Instantiate(waterPrefab, new Vector3(0,count*-33f,-1f), Quaternion.Euler(-90, 0, 0));
            waterCount++;
            if (waterCount >= 3)
                waterSpawning = false;
        }
    }

    public void spawnPuzzle()
    {

        GameObject aTable = theTable.GetRandomTable();
        GameObject worldBlock = (GameObject)Instantiate(aTable, new Vector3(0,count*-33f,0), Quaternion.Euler(-90, 0, 0));
        GameObject left = (GameObject)Instantiate(wall, new Vector3(-7.6f, count * -33f, -1.67f), Quaternion.Euler(-90, 0, 0));
        GameObject right = (GameObject)Instantiate(wall, new Vector3(8.7f, count * -33f, -1.67f), Quaternion.Euler(-90, 0, 0));
        spawnWater ();
        worldBlock.transform.parent = worldBlockParent;
        left.transform.parent = worldBlockParent;
        right.transform.parent = worldBlockParent;
        count++;
    }


}
