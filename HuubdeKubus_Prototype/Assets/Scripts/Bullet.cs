using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject floor;
    float marge = 2f;

	// Update is called once per frame
	void Update () {
        float PosX = floor.transform.position.x;
        float PosY = floor.transform.position.z;

        float SizeX = floor.transform.localScale.x;
        float SizeY = floor.transform.localScale.z;

        if (this.transform.position.x >= PosX + ((SizeX/2) + marge) || this.transform.position.x <= PosX - ((SizeX / 2) + marge))
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z >= PosY + ((SizeY / 2) + marge) || this.transform.position.z <= PosY - ((SizeY / 2) + marge))
        {
            Destroy(this.gameObject);
        }
    }
}
