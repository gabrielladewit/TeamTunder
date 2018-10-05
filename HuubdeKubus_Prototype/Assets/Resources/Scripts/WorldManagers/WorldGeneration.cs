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
    private int currentDifficulty = 0;
    ScoreUpdate scoreUpdate;
    LoadTables theTable;
    Transform worldBlockParent;

    void Start()
    {
        scoreUpdate = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
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

    private void getDifficulty()
    {
        if (scoreUpdate.scorez > 200)
            currentDifficulty = 1;
        if(scoreUpdate.scorez > 500)
            currentDifficulty = 2;
    }

    public void spawnPuzzle()
    {
        getDifficulty();
        GameObject aTable = theTable.GetRandomTable(currentDifficulty);
        GameObject worldBlock = (GameObject)Instantiate(aTable, new Vector3(0,count*-33f,0), Quaternion.Euler(-90, 0, 0));
        spawnWater ();
        worldBlock.transform.parent = worldBlockParent;
        count++;
    }


}
