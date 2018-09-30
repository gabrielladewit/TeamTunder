using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public float time = 3f;

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.transform.rotation = Random.rotation;
            child.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*2f);
        }
    }

	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
