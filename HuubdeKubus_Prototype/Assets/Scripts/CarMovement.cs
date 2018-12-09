using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    Transform[] places;
    Vector3 nextPos;
    Vector3 startPos;
    float distance;
    int nextLocation = 0;
    public float speed = 0.06f;
    public bool spinning = false;
    public bool left = false;
    public float speedRotate = 8;

    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        places = GetComponentsInChildren<Transform>();

        foreach (Transform go in places)
        {
            if (go.position != startPos)
                positions.Add(go.position);
        }
        nextPos = positions[nextLocation];
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, nextPos);

        this.transform.position = Vector3.MoveTowards(transform.position, nextPos, speed);

        if (distance < 0.75f)
        {
            nextLocation++;
            if (nextLocation >= transform.childCount)
                nextLocation = 0;
            nextPos = positions[nextLocation];
        }

        //if (Vector3.Distance(startPos, this.transform.position) > 45)
          //  this.transform.position = startPos;

        if (Vector3.Distance(nextPos, this.transform.position) < 1)
        {
            this.transform.position = startPos;
        }

        if (spinning)
        {
            if (!left)
                this.gameObject.transform.Rotate(0, speedRotate * 10 * Time.deltaTime, 0);
            else
                this.gameObject.transform.Rotate(0, speedRotate * -10 * Time.deltaTime, 0);
        }
    }
}
