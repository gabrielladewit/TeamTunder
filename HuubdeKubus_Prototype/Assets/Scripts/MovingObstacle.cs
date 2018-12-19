using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObstacle : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    private Transform[] places;

    private Vector3 nextPos;
    private Vector3 lastPos;

    private float distance;
    private float speed = 15f;

    private int nextLocation = 0;

    void Start()
    {
        //Vul de lijst met plekken van de kinderen van het GameObject.
        places = GetComponentsInChildren<Transform>();

        foreach (Transform go in places)
        {
            //Als je een empty game object toevoegt heet deze altijd GameObject. Er kunnen kinderen op een moving object zitten die geen plek horen te zijn (deze hebben dan ook al vaak een naam).
            if (go.name.Contains("GameObject"))
            {
                positions.Add(go.position);
            }
        }

        nextPos = positions[nextLocation];
    }

    void Update()
    {
        distance = Vector3.Distance(this.transform.position, nextPos);

        this.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
        
        //Iets voordat het GameObject bij de volgende positie is aangeven dat hij naar de volgende moet.
        if (distance < 0.5f)
        {
            lastPos = nextPos;

            nextLocation++;
            
            if (nextLocation >= positions.Count)
            {
                nextLocation = 0;
            }

            nextPos = positions[nextLocation];

            //Rotatie naar het volgende punt toe hoeft maar 1x te gebeuren.
            RotateObstaclesFacingTarget();
        }

    }

    void RotateObstaclesFacingTarget()
    {
        Vector3 targetDir = (nextPos - lastPos).normalized;
        float angle;

        //Onze levels zijn gedraaid op -90 graden. Als een GameObject naar links gaat draait deze dan van 360graden - angle om tot de goede rotatie uit te komen.
        if (targetDir.x < 0)
        {
            angle = 360 - Vector3.Angle(targetDir, Vector3.up);
        }
        else
        {
            angle = Vector3.Angle(targetDir, Vector3.up);
        }

        transform.localRotation = Quaternion.Euler(0, angle, 0);

    }
}
