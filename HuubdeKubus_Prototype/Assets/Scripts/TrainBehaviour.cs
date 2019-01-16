using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBehaviour : MonoBehaviour {

    public enum OccilationFuntion { Sine, Cosine }
    private float xPos, yPos, zPos;
    public int speed = 3;
    public int amplitude = 25;
    public void Start()
    {
        //to start at zero

        //xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;

        StartCoroutine(Oscillate(OccilationFuntion.Sine, 1f));

    }

    private IEnumerator Oscillate(OccilationFuntion method, float scalar)
    {
        while (true)
        {
            if (method == OccilationFuntion.Sine)
            {
                transform.position = transform.position + new Vector3(Mathf.Sin(Time.realtimeSinceStartup) * amplitude * Time.deltaTime * speed, 0.0f, 0.0f);
            }
            else if (method == OccilationFuntion.Cosine)
            {
                transform.position = transform.position + new Vector3(Mathf.Sin(Time.realtimeSinceStartup) * amplitude * Time.deltaTime * speed, 0.0f, 0.0f);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
