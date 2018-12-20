using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupScript : MonoBehaviour
{
    private static PickupBehaviour pickupBehaviour;

    private void Start()
    {
        if (pickupBehaviour == null)
        {
            pickupBehaviour = GameObject.Find("PickupHandler").GetComponent<PickupBehaviour>();
        }
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
            pickupBehaviour.Pickup(powerup.ToString());
            Destroy(this.gameObject);
        }
    }
}
