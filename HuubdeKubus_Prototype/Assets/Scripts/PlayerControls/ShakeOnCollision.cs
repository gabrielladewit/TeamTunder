using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeOnCollision : MonoBehaviour {

    Rigidbody rb;

    public float Magnitude = 2f;
    public float Roughness = 10f;
    public float FadeOutTime = 5f;

    void OnCollisionEnter(Collision collision)
    {
        rb = GetComponent<Rigidbody>();
        if (collision.gameObject.tag != "Floor")
        {
            if (CameraShaker.Instance != null)
            {
                CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, 0, FadeOutTime);
            }
        }
    }
}
