using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour {

    public GameObject player;
    Transform upPos;
    private Vector3 upDir;
    private float speed = 6.0f;

    public float explosionForce = 6.0f;
    public float explosionRadius = 5.0f;

    private Vector3 goUp;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerSphere");
        upPos= GameObject.Find("Up").transform;
        upDir = new Vector3(upPos.transform.position.x, upPos.transform.position.y, upPos.transform.position.z);
        goUp = new Vector3(transform.position.x + 100, transform.position.y + 100, transform.position.z + 100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("col player");

            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, upDir, speed * Time.deltaTime);


        //rb.AddExplosionForce(explosionForce, rb.transform.position, explosionRadius);



        this.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionForce);

        this.GetComponent<Rigidbody>().AddForce(goUp);

        yield return new WaitForSeconds(3);
        Debug.Log("coroutine done");

    }
}
