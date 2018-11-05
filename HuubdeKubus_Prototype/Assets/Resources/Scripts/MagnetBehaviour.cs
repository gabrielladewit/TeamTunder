using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : MonoBehaviour {

    public GameObject player;

    public float force;
    float distance, pullforce;
    Vector3 forceDirection;
    Pause pause;
    bool pull;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerSphere");
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        pullforce = force * 10;

        forceDirection = this.transform.position - player.transform.position;

        if (pull)
        {
            Debug.Log("hit");
            player.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullforce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            pause.DoDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pull = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            pull = false;
        }
    }
}
