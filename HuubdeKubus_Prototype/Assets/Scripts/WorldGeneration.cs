using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {


    GameObject playerObj;
    Manager manager;
    bool triggered = false;
    

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameWorld").GetComponent<Manager>();
        playerObj = GameObject.Find("PlayerSphere");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == playerObj.name && !triggered)
        {
            triggered = true;
            var theTable = GameObject.Find("EventSystem").GetComponent<LoadTables>().GetRandomTable();
            var worldBlock = (GameObject)Instantiate(theTable, new Vector3(0,manager.count*-32f,0), Quaternion.Euler(-90, 0, 0));
            worldBlock.transform.parent = GameObject.Find("GameWorld").transform;
            manager.count++;
            Destroy(this);
        }
    }
}
