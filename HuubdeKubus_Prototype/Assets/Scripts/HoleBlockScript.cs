using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBlockScript : MonoBehaviour {

    //Remove constraints when player collides with the hole
    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(0, 0, 50);
        other.attachedRigidbody.constraints = RigidbodyConstraints.None;
    }


    //Add constraints when player isn't on the hole
    private void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | 
            RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
