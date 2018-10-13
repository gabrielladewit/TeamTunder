using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

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
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 2);
	}



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pause.DoDie();
        }
    }
}
