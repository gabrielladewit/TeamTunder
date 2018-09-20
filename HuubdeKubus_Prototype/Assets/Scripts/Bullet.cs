using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject thePlayer;
    private Pause pause;

    private void Start()
    {
        thePlayer = GameObject.Find("PlayerSphere");
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update () {
        
        if(Vector3.Distance(thePlayer.transform.position, this.transform.position) > 50)
        {
            GameObject.Destroy(this);
        }

        this.transform.Translate(new Vector3(0,0,0.3f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
