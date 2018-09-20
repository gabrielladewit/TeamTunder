using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public float time = 3f;

	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
