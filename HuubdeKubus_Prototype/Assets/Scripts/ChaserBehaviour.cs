using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour {

    public GameObject player;
    public float speed;
    Pause pause;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PlayerSphere");
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (GetComponent<Collider>().GetType() == typeof(BoxCollider))
            {
                Debug.Log("triggerenter");
            }
            else if (GetComponent<Collider>().GetType() == typeof(SphereCollider))
            {
                Debug.Log("collisionenter");
                pause.DoDie();
            }
        }
    }

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            
        }
    }*/



      /*   if (collision.collider.GetType() == typeof(BoxCollider2D))
     {
         // do stuff only for the box collider
     }
     else if (collision.collider.GetType() == typeof(CircleCollider2D))
     {
         // do stuff only for the circle collider
     }*/
}
