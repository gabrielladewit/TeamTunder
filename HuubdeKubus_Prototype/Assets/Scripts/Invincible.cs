using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour {

    GameObject playerObj;
    static bool ignoringCollision = true;
    bool timerActive = false;
    bool triggered = false;
    float timer = 0f;
    
	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("PlayerSphere");
    }
	
	// Update is called once per frame
	void Update () {
        if (timerActive)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                SwitchCollision();
                Destroy(this.gameObject);
            }
        }
	}

    void SwitchCollision()
    {
        Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
        ignoringCollision = !ignoringCollision;
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject == playerObj && !this.triggered)
        {
            SwitchCollision();
            timerActive = true;
            this.triggered = true;
            this.transform.position = new Vector3(100, 100, 100);
        }
    }
}
