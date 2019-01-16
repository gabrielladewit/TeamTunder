using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandedCarMovement : MonoBehaviour
{
    Vector3 startPos;
    public float moveSpeed = 8;
    public float distance = 0.1f;
    public float turnRadius = 0;
    bool move = true;
    public float speedRotate = 8;
    public bool spinning = false;
    public bool left = false;

    public GameObject[] travelPoints;
    public int tPointIndex = 0;

    // Use this for initialization
    void Start()
    {

        startPos = this.transform.position;
        if (this.gameObject.name.Contains("2"))
            this.move = false;

        if (!this.move)
            StartCoroutine(startCar());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.move)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = (Vector3.MoveTowards(transform.position, travelPoints[tPointIndex].transform.position, step));

            if (Vector3.Distance(transform.position, travelPoints[tPointIndex].transform.position) < distance )
            {
                Debug.Log("Kaas");
                if(tPointIndex < travelPoints.Length - 1)
                {

                        transform.Rotate(0, turnRadius, 0);
                    tPointIndex++;
                }
                else
                {
                    tPointIndex = 0;
                    transform.Rotate(0, turnRadius, 0);
                }
                
            }

        }

        if (spinning)
        {
            if (!left)
                this.gameObject.transform.Rotate(0, speedRotate * 10 * Time.deltaTime, 0);
            else
                this.gameObject.transform.Rotate(0, speedRotate * -10 * Time.deltaTime, 0);
        }

    }

    IEnumerator startCar()
    {
        yield return new WaitForSeconds(2f);
        this.move = true;
    }
}
