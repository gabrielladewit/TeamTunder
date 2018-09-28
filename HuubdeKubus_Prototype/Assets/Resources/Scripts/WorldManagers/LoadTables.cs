using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTables : MonoBehaviour {

    public List<GameObject> tablePrefabs;
    public int x;

    // Use this for initialization
    void Start () {
        x = 0;
        tablePrefabs = new List<GameObject>(Resources.LoadAll<GameObject>("PrototypePrefabs"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetRandomTable()
    {
        GameObject table;

        //int x = Random.Range(0,tablePrefabs.Count
        table = tablePrefabs[x];
        x++;
        

        return table;
    }
}
