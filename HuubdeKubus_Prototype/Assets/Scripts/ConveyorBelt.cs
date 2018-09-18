using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public float beltSpeed;

    public float scrollSpeed = 0.5F;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(beltSpeed, 0, 0);
    }
}
