using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    public GameObject tablePrefab;
    public List<GameObject> tables;
    GameObject playerObj;
    private bool triggered;
    

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerSphere");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerObj.name)
        {
            var theTable = GameObject.Find("EventSystem").GetComponent<LoadTables>().GetRandomTable();
            var worldBlock = (GameObject)Instantiate(theTable, new Vector3(0,0,collision.gameObject.transform.position.z - 46.6f), Quaternion.identity);
            worldBlock.transform.parent = GameObject.Find("GameWorld").transform;
        }
    }
}
