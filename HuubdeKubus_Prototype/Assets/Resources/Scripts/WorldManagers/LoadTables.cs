using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTables : MonoBehaviour {

    public List<GameObject> tablePrefabs;
    int x = 0, i = 0;

    // Use this for initialization
    void Start () {
        tablePrefabs = new List<GameObject>(Resources.LoadAll<GameObject>("PrototypePrefabs"));
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

    public GameObject LoadLevel(int l)
    {
        string levelname = "level" + l;
        List<GameObject> level = new List<GameObject>(Resources.LoadAll<GameObject>(levelname));
        GameObject level1 = level[i];
        i++;

        return level1;
    }


}
