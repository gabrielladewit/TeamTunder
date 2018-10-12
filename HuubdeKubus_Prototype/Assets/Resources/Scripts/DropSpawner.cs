using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour {

    public DropBehaviour dropBehaviour;

    public float delayTime;
    public float dropSpeed;
    public float destroyTime = 5;

    float floorSizeX = 15f;
    float borderX;
    float delay;

	// Use this for initialization
	void Start () {
        borderX = floorSizeX / 2;
        delay = delayTime;
	}
	
	// Update is called once per frame
	void Update () {
        dropSpeed = dropBehaviour.speed;

        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            DropBehaviour clone;
            clone = Instantiate(dropBehaviour, new Vector3(Random.Range(-borderX, borderX), transform.position.y, transform.position.z),transform.rotation) as DropBehaviour;
            clone.speed = dropSpeed;

            delay = delayTime;
        }
	}
}
