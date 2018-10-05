using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTables : MonoBehaviour {

    private List<GameObject> easyPuzzles;
    private List<GameObject> mediumPuzzles;
    private List<GameObject> hardPuzzles;
    private GameObject table;
    // Use this for initialization
    void Start () {
        easyPuzzles = new List<GameObject>(Resources.LoadAll<GameObject>("EasyPuzzles"));
        mediumPuzzles = new List<GameObject>(Resources.LoadAll<GameObject>("MediumPuzzles"));
        hardPuzzles = new List<GameObject>(Resources.LoadAll<GameObject>("HardPuzzles"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetRandomTable(int difficulty)
    {
        if (difficulty == 0)
        {
            int x = Random.Range(0, easyPuzzles.Count);
            table = easyPuzzles[x];
        }
        if (difficulty == 1)
        {
            int x = Random.Range(0, mediumPuzzles.Count);
            table = mediumPuzzles[x];

        }
        if (difficulty == 2)
        {
            int x = Random.Range(0, hardPuzzles.Count);
            table = hardPuzzles[x];
        }

        return table;
    }
}
