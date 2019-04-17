using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CameraSlerp : MonoBehaviour
{
    //Fill in the tag(s) of the objects to slerp to in the inspector
    public List<string> objectTags;
    public List<Vector3> positionList;

    private Vector3 camPos, offset, aRelCenter, bRelCenter, posB, posA;

    private bool coroutineRunning = false, initiated = false;
    private float journeyTime, startTime;
    public int state = 1;

    //Shortcut for "delegate void..."
    public static event Action<int, Vector3> onStateChange;
    public static event Action onSlerpFinished;


    void Start()
    {
        AddPos();

        //Start the time for slerping
        startTime = Time.time;
        journeyTime = 2f;

        //Set position to finish line
        transform.position = positionList[0];

        //Set camera rotation to rotation in CameraTesting32 Scene so that the transition is smooth
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);

        //Calculate position with
        camPos = new Vector3(0, -15f, -25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!initiated)
        {
            //Get the center between the first and second position
            Vector3 center = (((posA + camPos) + (posB + camPos)) * 0.5f);

            //Move the center up so the camera moves in an arc
            center -= Vector3.back;

            //PosA and PosB relative to center of arc
            Vector3 aRelCenter = (posA + camPos) - center;
            Vector3 bRelCenter = (posB + camPos) - center;

            //Get completed fraction of slerp 
            float fracComplete = (Time.time - startTime) / journeyTime;

            //Move the camera 
            transform.position = Vector3.Slerp(aRelCenter, bRelCenter, fracComplete);
            transform.position += center;

            // Slerp is done, set next Slerp positions
            if ((Mathf.Round(transform.position.y) == Mathf.Round(posB.y + camPos.y)) && !coroutineRunning)
            {
                coroutineRunning = true;
                StartCoroutine(SetNewPos(1f));
            }
        }
    }

    //Set new A and B positions
    private IEnumerator SetNewPos(float time)
    {
        if (state <= positionList.Count - 1)
        {
            if (onStateChange != null)
            {
                onStateChange(state, posB);
            }
            yield return new WaitForSecondsRealtime(time);
            posA = positionList[state - 1];
            posB = positionList[state];
            startTime = Time.time;
            state++;
            //camManager.SlerpState = state;

            yield return coroutineRunning = false;
        }

        //Start the tutorial if it's level 1, or else start the game
        else if (state == positionList.Count)
        {
            initiated = true;

            if (onSlerpFinished != null)
            {
                onSlerpFinished();
            }
            yield return coroutineRunning = false;
        }

        yield return coroutineRunning = false;
    }

    //Add positions of the objects to list
    void AddPos()
    {
        foreach (string item in objectTags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(item))
            {
                positionList.Add(obj.transform.position);
            }
        }

        //Sort the list to make sure slerp happens in right order (from finisline to player)
        positionList = positionList.OrderBy(t => Vector3.Distance(positionList.Last(), t)).ToList();
    }
}
