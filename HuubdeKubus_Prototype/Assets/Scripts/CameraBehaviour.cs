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

    public bool initiated = false;
    bool Slerp1Done = false, 
        Slerp2Done = false, Slerp3Done = false;

    GameObject[] list;
    GameObject playerT, finishLine;

    PickupMovement starScript1, starScript2, starScript3;
    
    public float smoothSpeed = 0.125f;
    float startTime, journeyTime;

    Vector3 camPos, offset, posA, posB;

    

    // Use this for initialization
    void Start () {
        pauseScript = GameObject.Find("UI").GetComponent<Pause>();
        _levels = GameObject.Find("UI").GetComponent<Levels>();
        startTime = Time.time;
        journeyTime = 3f;

        //Get All Needed Objects
        //list = GameObject.FindGameObjectsWithTag("Star");
        finishLine = GameObject.Find("FinishLine");
        playerT = GameObject.Find("PlayerSphere");

        //Set first Slerp positions from finishline to star 3
        posA = finishLine.transform.position;
        posB = playerT.transform.position; //GetStarByName("Star3");
        //posB.z = -13;

        //Used to get camera mode from settings (deprecated)
        cameraMode = Modes.Strafe;//GameObject.Find("UI").GetComponent<StartOptions>().currentCameraMode;

        //Set Cam Rotation to Rotation in CameraTesting32 Scene so that transition is smooth
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);

        //To Calculate with
        camPos = new Vector3 (0, -15f, -25f);
        offset = new Vector3 (0, 2f, 2f);

    }

    void Update()
    {
        if (!initiated)
        {
            starScript1 = GetPickupMovementByName("Star1");
            starScript2 = GetPickupMovementByName("Star2");
            starScript3 = GetPickupMovementByName("Star3");

            //Set journeyTime so that transition is smooth
            journeyTime = Vector3.Distance(posA, posB) * 0.015f;

            float fracComplete = (Time.time - startTime) / journeyTime;

            Vector3 desiredPos = Vector3.Lerp(posA + camPos, posB + camPos, fracComplete);

            transform.position = desiredPos;
            
            // Slerp is done set next Slerp positions
            if ((transform.position.y == posB.y + camPos.y))
            {
                initiated = true;
                //SetNewPos();
            }
        }

        if (playerT != null && initiated)
        {
            if (cameraMode == Modes.Strafe)
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

    public void SetNewPos()
    {
        if (!Slerp1Done)
        {
            starScript3.Particles();
            //yield return new WaitForSecondsRealtime(time);
            Slerp1Done = true;
            posA = GetStarByName("Star3");
            posA.z = -13;
            posB = GetStarByName("Star2");
            posB.z = -13;
            startTime = Time.time;
            return;
        }
        else if (Slerp1Done && !Slerp2Done)
        {
            starScript2.Particles();
            //yield return new WaitForSecondsRealtime(time);
            Slerp2Done = true;
            posA = GetStarByName("Star2");
            posA.z = -13;
            posB = GetStarByName("Star1");
            posB.z = -13;
            startTime = Time.time;
            return;
        }
        else if (Slerp1Done && Slerp2Done && !Slerp3Done)
        {
            starScript1.Particles();
            //yield return new WaitForSecondsRealtime(time);
            Slerp3Done = true;
            posA = GetStarByName("Star1");
            posA.z = -13;
            posB = playerT.transform.position;
            startTime = Time.time;
            //yield break;
        }
        else if (Slerp1Done && Slerp2Done && Slerp3Done)
        {
            initiated = true;
            if (_levels.currentLevel == 1)
                pauseScript.PauseTutorial();
        }
    }

    public Vector3 GetStarByName(string name)
    {
        foreach (var item in list)
        {
            if(item.name == name)
            {
                return item.transform.position;
            }
        }
        return new Vector3();
    }

    public PickupMovement GetPickupMovementByName(string name)
    {
        foreach(var item in list)
        {
            if (item.name == name)
            {
                return item.GetComponent<PickupMovement>();
            }
        }
        return null;
    }
}