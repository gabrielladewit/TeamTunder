﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public enum Modes
    {
        Sway,
        Strafe
    }
    
    private Modes cameraMode;

    Pause pauseScript;
    Levels _levels;

    public bool initiated = false, coroutineRunning = false;

    public GameObject Star1, Star2, Star3;
    PickupMovement starScript1, starScript2, starScript3;

    private GameObject playerT;
    public float smoothSpeed = 0.125f, journeyTime;
    float startTime;
    Vector3 camPos, startPos, offset;
    private Vector3 centerPoint, startRelCenter, endRelCenter;
    GameObject finishLine;

    GameObject posA;
    GameObject posB;
    GameObject[] list;

    bool Slerp1Done = false, Slerp2Done = false, Slerp3Done = false;

    // Use this for initialization
    void Start () {
        pauseScript = GameObject.Find("UI").GetComponent<Pause>();
        _levels = GameObject.Find("UI").GetComponent<Levels>();
        //Start the time
        startTime = Time.time;
        journeyTime = 3f;

        //Get All Needed Objects
        list = GameObject.FindGameObjectsWithTag("Star");
        finishLine = GameObject.Find("FinishLine");
        playerT = GameObject.Find("PlayerSphere");

        //Set first Slerp positions from finishline to star 3
        posA = finishLine;
        posB = GetStarByName("Star3");

        //Used to get camera mode from settings (deprecated)
        cameraMode = Modes.Strafe;//GameObject.Find("UI").GetComponent<StartOptions>().currentCameraMode;
        
        //Set Cam at Finish
        startPos = transform.position;
        startPos.y = posA.transform.position.y - 10;
        transform.position = startPos;

        //Set Cam Rotation to Rotation in CameraTesting32 Scene so that transition is smooth
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);

        //To Calculate with
        camPos = new Vector3 (0, -15f, -25f);
        offset = new Vector3 (0, 2f, 2f);
	}

    void FixedUpdate()
    {
        if (!initiated)
        {
            Vector3 center = (((posA.transform.position + camPos) + (posB.transform.position + camPos)) * 0.5f);
            center -= Vector3.back;

            starScript1 = GetStarByName("Star1").GetComponent<PickupMovement>();
            starScript2 = GetStarByName("Star2").GetComponent<PickupMovement>();
            starScript3 = GetStarByName("Star3").GetComponent<PickupMovement>();

            //Set journeyTime so that transition is smooth
            //  journeyTime = Vector3.Distance(posA.transform.position, posB.transform.position) * 0.03f;

            Vector3 aRelCenter = posA.transform.position + camPos - center;
            Vector3 bRelCenter = posB.transform.position + camPos - center;

            float fracComplete = (Time.time - startTime) / journeyTime;

            transform.position = Vector3.Slerp(aRelCenter, bRelCenter, fracComplete);
            transform.position += center;

            // Slerp is done set next Slerp positions
            if ((transform.position.y == posB.transform.position.y + camPos.y) && !coroutineRunning)
            {
                coroutineRunning = true;
                StartCoroutine(SetNewPos(0.4f));
            }
        }

        if (playerT != null && initiated)
        {
            if (cameraMode == Modes.Sway)
            {
                Vector3 camPosition = playerT.transform.position + camPos;

                camPosition.x = 0;

                transform.LookAt(playerT.transform);
                Quaternion camRotation = this.transform.rotation;


                if (camRotation.y > 0.1f)
                {
                    //clamp right
                    camRotation.y = 0.1f;
                }
                else if (camRotation.y < -0.1f)
                {
                    camRotation.y = -0.1f;
                    //clamp left
                }

                transform.rotation = camRotation;
                transform.position = camPosition;
            } else if (cameraMode == Modes.Strafe)
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
    }

    public void GetCenter(Vector3 direction)
    {
        Vector3 endPos = playerT.transform.position;
        endPos.y += 15;
        centerPoint = (startPos + endPos) * 0.5f;
        centerPoint -= direction;
        startRelCenter = startPos - centerPoint;
        endRelCenter = endPos - centerPoint;
    }

    public IEnumerator SetNewPos(float time)
    {
        if (!Slerp1Done)
        {
            starScript3.Particles();
            yield return new WaitForSecondsRealtime(time);
            Slerp1Done = true;
            posA = GetStarByName("Star3");
            posB = GetStarByName("Star2");
            startTime = Time.time;
            yield return coroutineRunning = false;
        }
        else if (Slerp1Done && !Slerp2Done)
        {
            starScript2.Particles();
            yield return new WaitForSecondsRealtime(time);
            Slerp2Done = true;
            posA = GetStarByName("Star2");
            posB = GetStarByName("Star1");
            startTime = Time.time;
            yield return coroutineRunning = false;
        }
        else if (Slerp1Done && Slerp2Done && !Slerp3Done)
        {
            starScript1.Particles();
            yield return new WaitForSecondsRealtime(time);
            Slerp3Done = true;
            posA = GetStarByName("Star1");
            posB = playerT;
            startTime = Time.time;
            yield return coroutineRunning = false;
        }
        else if (Slerp1Done && Slerp2Done && Slerp3Done)
        {
            initiated = true;
            if (_levels.currentLevel == 1)
                pauseScript.PauseTutorial();
            yield return coroutineRunning = false;
        }
        yield return coroutineRunning = false;
    }

    public GameObject GetStarByName(string name)
    {
        foreach (var item in list)
        {
            if(item.name == name)
            {
                return item;
            }
        }
        return null;
    }
}