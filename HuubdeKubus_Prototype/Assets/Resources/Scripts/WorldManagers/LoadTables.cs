using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTables : MonoBehaviour {

    public List<GameObject> tablePrefabs;
    public List<GameObject> level1Prefabs;
    public List<GameObject> level2Prefabs;
    public List<GameObject> level3Prefabs;
    public List<GameObject> level4Prefabs;
    public List<GameObject> level5Prefabs;
    public int x;
    public int i;

    // Use this for initialization
    void Start () {
        x = 0;
        i = 0;
        tablePrefabs = new List<GameObject>(Resources.LoadAll<GameObject>(""));
        level1Prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("NewLevels"));
        level2Prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Level2"));
        level3Prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Level3"));
        level4Prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Level4"));
        level5Prefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Level5"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetRandomTable()
    {
        GameObject table;

        int x = Random.Range (0, tablePrefabs.Count);
        table = tablePrefabs[x];
        
        return table;
    }

    public GameObject LoadLevel1()
    {
        GameObject level1;
        level1 = level1Prefabs[i];
        i++;

        return level1;
    }

    public GameObject LoadLevel2()
    {
        GameObject level2;
        level2 = level2Prefabs[i];
        i++;

        return level2;
    }

    public GameObject LoadLevel3()
    {
        GameObject level3;
        level3 = level3Prefabs[i];
        i++;

        return level3;
    }

    public GameObject LoadLevel4()
    {
        GameObject level4;
        level4 = level4Prefabs[i];
        i++;

        return level4;
    }

    public GameObject LoadLevel5()
    {
        GameObject level5;
        level5 = level5Prefabs[i];
        i++;

        return level5;
    }

}
