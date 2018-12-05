using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupMovement : MonoBehaviour
{
    static PickupBehaviour pUp;
    public ParticleSystem starParticles;

    private void Start()
    {
        pUp = GameObject.Find("PickupHandler").GetComponent<PickupBehaviour>();
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

            if (starParticles != null)
                starParticles.Play();


            if (this.powerup == Powerups.Star)
            {
                Destroy(this.gameObject, 1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
