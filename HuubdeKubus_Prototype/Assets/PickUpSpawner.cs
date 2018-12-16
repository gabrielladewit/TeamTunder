using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

    public GameObject pickup;
    public float AmountOfPickups;
    float count = 0;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < AmountOfPickups/10; i++)
        {
            for (int x = 0; x < AmountOfPickups / 5; x++)
            {
                Vector3 spawnPos = new Vector3(this.transform.position.x + 3 * count, this.transform.position.y - 3 * i, this.transform.position.z);
                GameObject go = (GameObject)Instantiate(pickup, this.transform);
                go.transform.position = spawnPos;
                count++;
            }
            count = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {

		

	}
}
