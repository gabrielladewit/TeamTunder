using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    Pause pauseScript;
    Levels _levels;

    public bool initiated = false, coroutineRunning = false, Lerp1Done = false,
        Lerp2Done = false, skipTutorial = false;

    GameObject playerT, finishLine, huubKuub;
    
    float startTime;

    Vector3 camPos, offset, posA, posB;

    // Total distance between the markers for lerping
    private float journeyLength;
    public float cameraspeed = 50f;

    // Use this for initialization
    void Start () {
        pauseScript = GameObject.Find("UI").GetComponent<Pause>();
        _levels = GameObject.Find("UI").GetComponent<Levels>();
        startTime = Time.time;

        //Get all needed objects
        finishLine = GameObject.Find("FinishLine");
        playerT = GameObject.Find("PlayerSphere");
        huubKuub = GameObject.Find("Huub");

        //Set first lerp positions (from finish line to player)
        posA = new Vector3(finishLine.transform.position.x, finishLine.transform.position.y, -25); 
        posB = new Vector3(playerT.transform.position.x, playerT.transform.position.y, -25);

        //Set camera position at finish
        Vector3 startPos = transform.position;
        startPos.y = posA.y - 10;
        transform.position = startPos;

        //Set camera rotation to rotation in CameraTesting32 scene
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);

        //To Calculate with
        //Used when focusing on Huub?
        camPos = new Vector3(0, -15f, -25f);
        offset = new Vector3 (0, 2f, 2f);
	}

    void FixedUpdate()
    {
        if (skipTutorial == false && Input.GetMouseButton(0))
        {
            Lerp1Done = true;
            StartCoroutine(SetNewPos(0));
            skipTutorial = true;
        }

        if (!initiated)
        {
            journeyLength = Vector3.Distance(posA + camPos, posB + camPos);

            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * cameraspeed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength ;

            //Lerp 1: from finishline to player
            transform.position = Vector3.Lerp(posA + camPos, posB + camPos, fracJourney);

            //Lerp is done, set next lerp positions
            if ((transform.position.y == posB.y + camPos.y) && !coroutineRunning)
            {
                coroutineRunning = true;
                StartCoroutine(SetNewPos(0.4f));
            }
        }

        //Camera follows player after lerps are done 
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

    public IEnumerator SetNewPos(float time)
    {
        //Lerp 2: From player to Huub
        if (!Lerp1Done)
        {
            yield return new WaitForSecondsRealtime(time);
            Lerp1Done = true;

            posA = new Vector3(playerT.transform.position.x, playerT.transform.position.y, -28);
            posB = new Vector3(huubKuub.transform.position.x, 10, -7);
            startTime = Time.time;

            yield return coroutineRunning = false;
        }

        //Lerp 3: From Huub to player
        else if (Lerp1Done && !Lerp2Done)
        {
            huubKuub.GetComponent<AudioSource>().Play();
            yield return new WaitForSecondsRealtime(time*2);
            Lerp2Done = true;

            posA = new Vector3(huubKuub.transform.position.x, 10, -7);
            posB = playerT.transform.position;
            startTime = Time.time;
            yield return coroutineRunning = false;
        }

        //Start the tutorial if it's level 1
        else if (Lerp1Done && Lerp2Done)
        {
            initiated = true;
            if (_levels.currentLevel == 1)
                pauseScript.PauseTutorial();
            yield return coroutineRunning = false;
        }
        yield return coroutineRunning = false;
    }
}