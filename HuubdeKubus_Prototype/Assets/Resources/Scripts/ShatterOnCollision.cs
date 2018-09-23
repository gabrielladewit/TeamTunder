using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterOnCollision : MonoBehaviour {

    public GameObject replacement;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Instantiate(replacement, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
