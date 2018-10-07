using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour {

    public List<GameObject> levelPrefabs;
    public int x;

    // Use this for initialization
    void Start()
    {
        x = 0;
        levelPrefabs = new List<GameObject>(Resources.LoadAll<GameObject>("Level1"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject LoadLevel1()
    {
        GameObject level1;
        level1 = levelPrefabs[x];
        x++;

        return level1;
    }
}
