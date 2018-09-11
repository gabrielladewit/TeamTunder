using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject tablePrefab;
    public List<GameObject> tablePrefabs;
    GameObject playerObj;
    private bool triggered;
    

	// Use this for initialization
	void Start () {
        tablePrefabs = new List<GameObject>(Resources.LoadAll<GameObject>("PuzzlePrefabs"));
        playerObj = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] tables = GameObject.FindGameObjectsWithTag("Tables");
        foreach (GameObject table in tables)
        {
            if(table.transform.position.z > 64)
            {
                Destroy(table);
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.transform.position.z);
        if (collision.gameObject.name == playerObj.name)
        {
            var worldBlock = (GameObject)Instantiate(tablePrefab, new Vector3(0,0,-46.6f), Quaternion.identity);
            worldBlock.transform.parent = GameObject.Find("GameWorld").transform;
            worldBlock.GetComponentInChildren<WorldGeneration>().tablePrefab = tablePrefabs[Random.Range(0,tablePrefabs.Count + 1)];
            Destroy(GetComponent<WorldGeneration>());
        }
    }
}
