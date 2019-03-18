using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupMovement : MonoBehaviour
{
    static PickupBehaviour pUp;
    //public ParticleSystem starParticles;
    Collider col;

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
                StartCoroutine(StarPickup());
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator StarPickup()
    {
        GameObject starParticles = ObjectPool.SharedInstance.GetPooledObject("StarParticles");

        if (starParticles != null)
        {
            starParticles.transform.position = this.transform.position;
            starParticles.transform.rotation = this.transform.rotation;
            starParticles.SetActive(true);
            starParticles.GetComponent<ParticleSystem>().Play();
        }

        col.enabled = !col.enabled;
        yield return new WaitForSeconds(1);
        //starParticles.GetComponent<ParticleSystem>().Clear();
        starParticles.SetActive(false);
    }

    public void Particles()
    {
        //starParticles.Play();
    }
}
