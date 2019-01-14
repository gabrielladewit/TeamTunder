using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObstacle : MonoBehaviour {
    private List<Vector3> positions = new List<Vector3>();
    Transform[] places;

    Vector3 nextPos;
    Vector3 lastPos;
    Vector3 startPos;

    float distance;
    bool dontRotate = false;
    int nextLocation = 0;

    public float speed = 15f;
    // Use this for initialization
    void Start()
    {
        if (this.gameObject.GetComponent<RotateObstacle>() != null)
            dontRotate = true;

        startPos = this.transform.position;
        places = GetComponentsInChildren<Transform>();

        foreach (Transform go in places)
        {
            if (go.position != startPos && go.name.Contains("GameObject"))
                positions.Add(go.position);
        }
    
        nextPos = positions[nextLocation];
    }
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(this.transform.position, nextPos);
        this.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);

        if (distance < 0.75f)
        {
            lastPos = nextPos;
            nextLocation++;
            if (nextLocation >= positions.Count)
                nextLocation = 0;
            nextPos = positions[nextLocation];

            if(!dontRotate)
                RotateDieKutAutosGoed();
        }

    }

    void RotateDieKutAutosGoed()
    {
        Vector3 targetDir = (nextPos - lastPos).normalized;
        float angle;

        if (targetDir.x < 0)
            angle = 360 - Vector3.Angle(targetDir, Vector3.up);
        else
            angle = Vector3.Angle(targetDir, Vector3.up);

        transform.localRotation = Quaternion.Euler(0, angle, 0);

    }
}
