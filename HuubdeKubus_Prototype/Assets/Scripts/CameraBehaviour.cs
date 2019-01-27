using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Pause pauseScript;
    Levels _levels;
    GameObject[] list;

    public bool initiated = false;
    private bool Slerp1Done = false, Slerp2Done = false, Slerp3Done = false, coroutineRunning = false, skipSlerp = false;

    private GameObject playerT, finishLine;
    private float journeyTime = 2f, startTime;

    private Vector3 camPos, offset, aRelCenter, bRelCenter, posA, posB;

    // Use this for initialization
    void Start()
    {
        pauseScript = GameObject.Find("UI").GetComponent<Pause>();
        _levels = GameObject.Find("UI").GetComponent<Levels>();

        //Get All Needed Objects
        list = GameObject.FindGameObjectsWithTag("Star");
        finishLine = GameObject.Find("FinishLine");
        playerT = GameObject.Find("PlayerSphere");

        //Start the time for slerping
        startTime = Time.time;

        //Set first Slerp positions from finishline to star 3
        posA = finishLine.transform.position;
        posB = GetStarByName("Star3");
        posB.z = -13;

        //Set camera position to finishline
        Vector3 startPos = transform.position;
        startPos.y = posA.y - 10;
        transform.position = startPos;

        //Set camera rotation to rotation in CameraTesting32 Scene so that the transition is smooth
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);

        //Calculate position with
        camPos = new Vector3(0, -15f, -25f);
        offset = new Vector3(0, 2f, 2f);
    }

    void Update()
    {
        //Speeds up slerp if player taps 
        if (skipSlerp == false && Input.GetMouseButton(0))
        {
            journeyTime = 0.7f;
            skipSlerp = true;
        }
    

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

            transform.position = Vector3.Slerp(aRelCenter, bRelCenter, fracComplete);
            transform.position += center;

            // Slerp is done, set next Slerp positions
            if ((Mathf.Round(transform.position.y) == Mathf.Round(posB.y + camPos.y)) && !coroutineRunning)
            {
                coroutineRunning = true;
                StartCoroutine(SetNewPos(0.4f));
            }
        }

        //After slerps are done, camera follows player
        if (playerT != null && initiated)
        {
            Vector3 camPosition = playerT.transform.position + camPos;

            if (camPosition.x > 60f)
            {
                camPosition.x = 60f;
            }
            else if (camPosition.x < -60f)
            {
                camPosition.x = -60f;
            }

            transform.position = camPosition;

            Vector3 lookAtPos = playerT.transform.position + offset;
            transform.LookAt(lookAtPos);
        }
    }

    //Set new positions for each slerp
    public IEnumerator SetNewPos(float time)
    {
        if (!Slerp1Done)
        {
            GetPickupMovementByName("Star3").Particles();

            yield return new WaitForSecondsRealtime(time);
            Slerp1Done = true;
            posA = GetStarByName("Star3");
            posA.z = -13;
            posB = GetStarByName("Star2");
            posB.z = -13;
            startTime = Time.time;
            yield return coroutineRunning = false;
        }
        else if (Slerp1Done && !Slerp2Done)
        {
            GetPickupMovementByName("Star2").Particles();

            yield return new WaitForSecondsRealtime(time);
            Slerp2Done = true;
            posA = GetStarByName("Star2");
            posA.z = -13;
            posB = GetStarByName("Star1");
            posB.z = -13;
            startTime = Time.time;
            yield return coroutineRunning = false;
        }
        else if (Slerp1Done && Slerp2Done && !Slerp3Done)
        {
            GetPickupMovementByName("Star1").Particles();

            yield return new WaitForSecondsRealtime(time);
            Slerp3Done = true;
            posA = GetStarByName("Star1");
            posA.z = -13;
            posB = playerT.transform.position;
            startTime = Time.time;
            yield return coroutineRunning = false;
        }

        //Start the tutorial if it's level 1, or else start the game
        else if (Slerp1Done && Slerp2Done && Slerp3Done)
        {
            initiated = true;
            if (_levels.currentLevel == 1)
                pauseScript.PauseTutorial();
            yield return coroutineRunning = false;
        }
        yield return coroutineRunning = false;
    }

    //Get position of specific star
    public Vector3 GetStarByName(string name)
    {
        foreach (var item in list)
        {
            if (item.name == name)
            {
                return item.transform.position;
            }
        }
        return new Vector3();
    }

    //Get script from star (for particle animation)
    public PickupMovement GetPickupMovementByName(string name)
    {
        foreach (var item in list)
        {
            if (item.name == name)
            {
                return item.GetComponent<PickupMovement>();
            }
        }
        return null;
    }
}