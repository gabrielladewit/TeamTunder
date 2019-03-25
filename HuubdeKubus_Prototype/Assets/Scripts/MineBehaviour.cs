using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{

    //public GameObject explosion;
    private GameObject player;
    public float force = 5, addRadius, delay = 0, destroyDelay = 1f;
    float radius, tempDelay;
    bool onOff, on;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerSphere");
        if (this.gameObject.GetComponent<SphereCollider>() != null)
            radius = this.gameObject.GetComponent<SphereCollider>().radius;
        tempDelay = delay;
    }

    void Update()
    {
        if (onOff == true)
        {
            Debug.Log("onoff");
            tempDelay -= 2f * Time.deltaTime;

            if (tempDelay <= 0.0f)
            {
                Debug.Log("onoff2");

                Rigidbody rb = player.GetComponent<Rigidbody>();

                Vector3 levelledPosition = this.transform.position;
                levelledPosition.z = player.transform.position.z;

                Vector3 mineDirection = rb.transform.position - levelledPosition;
                mineDirection = mineDirection.normalized;

                mineDirection.x = mineDirection.x * 2;

                rb.AddForce(mineDirection * force * 100);
                onOff = false;
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            onOff = true;
            on = true;
            //StartCoroutine(ObjectPool.SharedInstance.PlaceParticles("Explosion", this.transform.position, 3f));
            StartCoroutine(PlaceParticles("Explosion"));
            tempDelay = delay;
            //Destroy(this);
        }
    }

    /*IEnumerator PlaceParticles(string tag)
    {
        Debug.Log("2");

        GameObject explosion2 = ObjectPool.SharedInstance.GetPooledObject(tag);
        if (explosion2 != null)
        {
            Debug.Log("3");

            explosion2.transform.position = this.transform.position;
            explosion2.transform.rotation = this.transform.rotation;
            explosion2.SetActive(true);

            Debug.Log("3");

            onOff = true;
            tempDelay = delay;
            //this.gameObject.GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(destroyDelay);

            //explosion2.GetComponent<ParticleSystem>().Clear();
            Debug.Log("setactive false");
            explosion2.SetActive(false);
        }*/

        //StartCoroutine(PlaceParticles("StarParticles"));

        public IEnumerator PlaceParticles(string tag)
        {
        Debug.Log("IEnumerator");

        GameObject explParticles = ObjectPool.SharedInstance.GetPooledObject(tag);

            if (explParticles != null && on == false)
            {
            Debug.Log("first if");

            explParticles.transform.position = this.transform.position;
                explParticles.transform.rotation = this.transform.rotation;
                explParticles.SetActive(true);
                explParticles.GetComponent<ParticleSystem>().Play();
                on = true;
                onOff = true;
                tempDelay = delay;
        }

            if (on == true)
            {
            Debug.Log("on = true");

            yield return new WaitForSeconds(2f);

                explParticles.GetComponent<ParticleSystem>().Clear();
                explParticles.SetActive(false);
                on = false;
            }
        }
    }
