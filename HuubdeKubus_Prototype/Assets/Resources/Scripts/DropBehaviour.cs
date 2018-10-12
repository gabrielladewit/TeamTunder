using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehaviour : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(this);
    }
}
