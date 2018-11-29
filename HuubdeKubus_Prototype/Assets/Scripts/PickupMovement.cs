﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupMovement : MonoBehaviour
{
    public float verticalSpeed = 4;
    public float amplitude = 0.05f;
    public float rotationSpeed = 1;
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
            starParticles.Play();
            Destroy(this.gameObject, 1);
        }
    }
}

class MovementSystem : ComponentSystem
{
    struct Components
    {
        public PickupMovement move;
        public Transform trans;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Components>())
        {
            e.trans.Rotate(Vector3.up * e.move.rotationSpeed);
            e.trans.position = e.trans.position + new Vector3(0.0f, 0.0f, Mathf.Sin(Time.realtimeSinceStartup * e.move.verticalSpeed) * e.move.amplitude);
        }
    }
}
