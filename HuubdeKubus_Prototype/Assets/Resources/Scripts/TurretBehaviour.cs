using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour {

    public GameObject player;
    public BulletBehaviour bullet;
    public Transform firePoint;

    public float bulletSpeed;
    public float timeDelay;
    private float shotCounter;
    public float radius;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.LookAt(targetPos);

        float distanceP = (transform.position - player.transform.position).sqrMagnitude;

        if (distanceP < radius)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeDelay;
                BulletBehaviour clone = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletBehaviour;
                clone.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
	}
}
