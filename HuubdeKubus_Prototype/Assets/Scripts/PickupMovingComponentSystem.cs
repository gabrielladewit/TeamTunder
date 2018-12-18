using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

class PickupMovingComponentSystem : ComponentSystem
{
    float rotationSpeed = 1f;
    float amplitude = 0.05f;
    float verticalSpeed = 4f;
    float speed = 30f;

    struct Components
    {
        public PickupMovement move;
        public Transform trans;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Components>())
        {
            e.trans.Rotate(Vector3.up * rotationSpeed * Time.deltaTime *speed);
            e.trans.position = e.trans.position + new Vector3(0.0f, 0.0f, Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude * Time.deltaTime *speed);
        }
    }
}
