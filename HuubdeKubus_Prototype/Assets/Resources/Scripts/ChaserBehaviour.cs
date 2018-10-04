using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour {

    private GameObject player;
    public float speed, range;
    float minY, maxY;
    Pause pause;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("PlayerSphere");
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update() {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        if (dist <= range)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pause.DoDie();
        }
    }
}
