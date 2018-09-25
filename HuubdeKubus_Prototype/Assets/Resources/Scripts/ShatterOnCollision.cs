using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollision : MonoBehaviour {

    public GameObject replacement;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject.Instantiate(replacement, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
