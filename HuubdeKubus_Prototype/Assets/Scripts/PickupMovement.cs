using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupMovement : MonoBehaviour
{
    static PickupBehaviour pUp;
    Collider col;
    bool on = false;

    private void Start()
    {
        pUp = GameObject.Find("PickupHandler").GetComponent<PickupBehaviour>();
        col = gameObject.GetComponent<Collider>();
    }

    public enum Powerups
    {
        Multiplier,
        Breakable,
        MoveFaster,
        Coin,
        Invert,
        Star
    }

    public Powerups powerup;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "PlayerSphere")
        {
            pUp.Pickup(powerup.ToString());
            if (powerup.ToString() == "Star")
            {
                StartCoroutine(PlaceParticles("StarParticles"));
            }
            StartCoroutine(Destroy());
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
            on = false;
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
