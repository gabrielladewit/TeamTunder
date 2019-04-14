using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTables : MonoBehaviour
{
    Levels levels;
    Transform worldBlockParent;

    PlayerController playerController;
    HuubBehaviour huubBehaviour;

    public List<GameObject> tablePrefabs;
    public GameObject camFix;
    int x = 0, i = 0;

    // Use this for initialization
    void Start ()
    {
        playerController = GameObject.Find("PlayerSphere").GetComponent<PlayerController>();
        huubBehaviour = GameObject.Find("Top").GetComponent<HuubBehaviour>();
        tablePrefabs = new List<GameObject> (Resources.LoadAll<GameObject> ("PrototypePrefabs"));
        worldBlockParent = GameObject.Find ("GameWorld").transform;
        levels = GameObject.Find ("UI").GetComponent<Levels> ();
        LoadLevel (levels.currentLevel);
    }
	
    // Update is called once per frame
    void Update ()
    {
		
    }

    public GameObject GetRandomTable ()
    {
        GameObject table;

        int x = Random.Range (0, tablePrefabs.Count);
        table = tablePrefabs [x];
        
        return table;
    }

    public void LoadLevel (int l)
    {
        string levelname = "levels/level" + l;
        List<GameObject> level = new List<GameObject> (Resources.LoadAll<GameObject> (levelname));

        for (int x = 0; x < level.Count; x++)
        {
            GameObject worldBlock = (GameObject)Instantiate (level [x], new Vector3 (0, x * -33f, 0), Quaternion.Euler (-90, 0, 0));
            worldBlock.transform.parent = worldBlockParent;
            camFix.SetActive(true);
            huubBehaviour.SetCamera();
            //playerController.SetCamera();
        }
    }
        
}
