using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTargetLerpRoutine : MonoBehaviour {

    public float x = 1f;
    public Transform target;

	void Start () {
        StartCoroutine("LerpTo", target);
	}
	
    IEnumerator LerpTo(Transform target)
    {
        // While the player is moving
        while (Vector3.Distance(target.position, transform.position) > 0.05f)
        {
            //                                  From                To              Over Time x
            transform.position = Vector3.Lerp(transform.position, target.position, x * Time.deltaTime);
            // Go to next frame and restart while
            yield return null;
        }

        // While loop broke so the player stopped moving
        // Optional: Excecute point reached code (shoot?)
        StopCoroutine("LerpTo");
    }
	
}
