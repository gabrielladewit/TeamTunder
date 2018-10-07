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
    public Levels levelManager;
    LoadTables theTable;
    Transform worldBlockParent;

    StartOptions theLevel;

    void Start()
    {
        theTable = GameObject.Find ("EventSystem").GetComponent<LoadTables> ();
        levelManager = GameObject.Find("UI").GetComponentInChildren<Levels>();
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
        switch(levelManager.levelCount)
        {
            case 1:
                GameObject aTable = theTable.LoadLevel1();
                GameObject worldBlock = (GameObject)Instantiate(aTable, new Vector3(0, count * -33f, 0), Quaternion.Euler(-90, 0, 0));
                worldBlock.transform.parent = worldBlockParent;
                count++;
                Debug.Log("level 1");
                break;

            case 2:
                GameObject aTable2 = theTable.LoadLevel2();
                GameObject worldBlock2 = (GameObject)Instantiate(aTable2, new Vector3(0, count * -33f, 0), Quaternion.Euler(-90, 0, 0));
                worldBlock2.transform.parent = worldBlockParent;
                count++;
                Debug.Log("level 2");
                break;

            case 3:
                GameObject aTable3 = theTable.LoadLevel3();
                GameObject worldBlock3 = (GameObject)Instantiate(aTable3, new Vector3(0, count * -33f, 0), Quaternion.Euler(-90, 0, 0));
                worldBlock3.transform.parent = worldBlockParent;
                count++;
                Debug.Log("level 3");
                break;

            case 4:
                GameObject aTable4 = theTable.LoadLevel4();
                GameObject worldBlock4 = (GameObject)Instantiate(aTable4, new Vector3(0, count * -33f, 0), Quaternion.Euler(-90, 0, 0));
                worldBlock4.transform.parent = worldBlockParent;
                count++;
                Debug.Log("level 4");
                break;

            case 5:
                GameObject aTable5 = theTable.LoadLevel5();
                GameObject worldBlock5 = (GameObject)Instantiate(aTable5, new Vector3(0, count * -33f, 0), Quaternion.Euler(-90, 0, 0));
                worldBlock5.transform.parent = worldBlockParent;
                count++;
                Debug.Log("level 5");
                break;
        }

    }

}
