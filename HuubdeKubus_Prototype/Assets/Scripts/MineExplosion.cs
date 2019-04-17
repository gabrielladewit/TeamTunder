using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {

    private GameObject player;
    Collider col;
    public float force = 5, addRadius, delay = 0, destroyDelay = 1f;
    float radius, tempDelay;
    bool onOff, on;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PlayerSphere");
        col = GetComponent<CapsuleCollider>();
        if (this.gameObject.GetComponent<SphereCollider>() != null)
            radius = this.gameObject.GetComponent<SphereCollider>().radius;
        tempDelay = delay;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "PlayerSphere")
        {
            col.enabled = false;
            onOff = true;
            Explode();
            StartCoroutine(PlaceParticles("Explosion"));
        }
    }

    private IEnumerator PlaceParticles(string tag)
    {
        GameObject particles = ObjectPool.SharedInstance.GetPooledObject(tag);

        if (particles != null && on == false)
        {
            particles.transform.position = this.transform.position;
            particles.transform.rotation = this.transform.rotation;
            particles.SetActive(true);
            particles.GetComponent<ParticleSystem>().Play();
            on = true;
        }

        if (on == true)
        {
            yield return new WaitForSeconds(2f);

            particles.SetActive(false);
            Destroy(gameObject);
            on = false;
        }
    }

    private void Explode()
    {
        if (onOff == true)
        {
            tempDelay -= 2f * Time.deltaTime;

            if (tempDelay <= 0.0f)
            {
                onOff = false;
                Rigidbody rb = player.GetComponent<Rigidbody>();

                Vector3 levelledPosition = this.transform.position;
                levelledPosition.z = player.transform.position.z;

                Vector3 mineDirection = rb.transform.position - levelledPosition;
                mineDirection = mineDirection.normalized;

                mineDirection.x = mineDirection.x * 2;

                rb.AddForce(mineDirection * force * 100);
            }
        }
    }
}
