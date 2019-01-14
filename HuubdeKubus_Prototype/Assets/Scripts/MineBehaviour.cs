using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {

    public GameObject explosion;
    private GameObject player;
    public float force = 5, addRadius, delay = 0;

    float radius, tempDelay;
    bool onOff;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PlayerSphere");
        if(this.gameObject.GetComponent<SphereCollider>() != null)
            radius = this.gameObject.GetComponent<SphereCollider>().radius;
        tempDelay = delay;
    }

    void Update()
    {
        if (onOff)
        {
            tempDelay -= 2f * Time.deltaTime;

            if (tempDelay <= 0.0f)
            {
                Rigidbody rb = player.GetComponent<Rigidbody>();
                
                Vector3 levelledPosition = this.transform.position;
                levelledPosition.z = player.transform.position.z;

                Vector3 mineDirection = rb.transform.position - levelledPosition;
                mineDirection = mineDirection.normalized;

                //Debug.Log("mineDirection: " + mineDirection.x + "  , " + mineDirection.y + "  ," + mineDirection.z);
                
                mineDirection.x = mineDirection.x * 2;

                //Debug.Log("mineForce: " + mineDirection * (force * 100));

                rb.AddForce(mineDirection * force * 100);

                onOff = false;
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        onOff = true;
        tempDelay = delay;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
}
