using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeOnCollision : MonoBehaviour {

    public float Magnitude = 2f;
    public float Roughness = 10f;
    public float FadeOutTime = 5f;

    void OnCollisionEnter(Collision collision)
    {
        CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, 0, FadeOutTime);
    }

}
