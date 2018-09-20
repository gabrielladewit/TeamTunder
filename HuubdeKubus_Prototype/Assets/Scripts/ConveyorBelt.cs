using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public GameObject conveyor;
    public Transform endpoint;
    private float beltSpeed = 10;

    public float scrollSpeed = 0.5F;
    public Renderer rend;

    public Vector3 start;
    public Vector3 end;
    public Vector3 direction;

    void Start()
    {
        rend = GetComponent<Renderer>();
        start = this.gameObject.transform.GetChild(0).position;
        end = this.gameObject.transform.GetChild(1).position;

        var heading = end - start;
        var distance = heading.magnitude;
        direction = heading / distance;
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(-offset, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(direction * beltSpeed);
    }
} 