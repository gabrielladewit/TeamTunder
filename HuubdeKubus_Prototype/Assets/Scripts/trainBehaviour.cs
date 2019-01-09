using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainBehaviour : MonoBehaviour {

    public enum OccilationFuntion { Sine, Cosine }
    private float xPos, yPos, zPos;
    public void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        //to start at zero
        StartCoroutine(Oscillate(OccilationFuntion.Sine, 5f));
        //to start at scalar value
        //StartCoroutine (Oscillate (OccilationFuntion.Cosine, 1f));
    }

    private IEnumerator Oscillate(OccilationFuntion method, float scalar)
    {
        while (true)
        {
            if (method == OccilationFuntion.Sine)
            {
                transform.position = new Vector3(Mathf.Sin(Time.realtimeSinceStartup * 1) * 50, yPos, zPos);
            }
            else if (method == OccilationFuntion.Cosine)
            {
                transform.position = new Vector3(Mathf.Sin(Time.realtimeSinceStartup * 1) * 50, yPos, zPos);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
