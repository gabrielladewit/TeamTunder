using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour {
    Vector3 startPos;
    public float moveSpeed = 8;
    public float distance = 80;
    bool move = true;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
        if(this.gameObject.name.Contains ("2"))
            this.move = false;

        if (!this.move)
            StartCoroutine (startCar ());
	}
	
	// Update is called once per frame
	void Update () {
        if (this.move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        if(Vector3.Distance (startPos, this.transform.position) > distance)
            this.transform.position = startPos;
	}

    IEnumerator startCar()
    {
        yield return new WaitForSeconds (2f);
        this.move = true;
    }
}

