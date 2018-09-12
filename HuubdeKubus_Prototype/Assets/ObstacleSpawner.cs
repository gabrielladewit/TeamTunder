using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject o_walls, o_turn, o_zigzag;

    private Vector3 wallsBegin = new Vector3(-25f,1.5f,5f);
    private Vector3 zigzagBegin = new Vector3(0, 1.5f, 74f);
    private Vector3 turnBegin = new Vector3(0, -1f, 0);

    public GameObject leftWall, rightWall, upRot, downRot;

    public int speed = 6;
    public int rotSpeed = 12;

    bool start = true;

    int scene = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (scene)
        {
            case 0:
                Walls();
                break;
            case 1:
                ZigZag();
                break;
            case 2:
                Turn();
                break;
        }
    }

    public void Walls() {

        if (start)
        {
            o_walls.transform.position = wallsBegin;
            start = false;
        }

        if (!start) {
            o_walls.transform.Translate(speed * Time.deltaTime, 0, 0);

            if (o_walls.transform.position.x >= 104f)
            {
                scene++;
                start = true;
            }
        }
    }

    public void ZigZag() {
        if (start)
        {
            o_zigzag.transform.position = zigzagBegin;
            start = false;
        }

        if (!start)
        {
            o_zigzag.transform.Translate(0, 0, -speed * Time.deltaTime);

            if (o_zigzag.transform.position.z <= -95f)
            {
                scene++;
                start = true;
            }
        }
    }

    public void Turn() {

        bool check1 = false;
        bool check2 = false;

        if (rightWall.transform.position.x <= 16f)
        {
            check1 = true;
        }

        if (upRot.transform.position.z <= 10f)
        {
            check2 = true;
        }

        if (!check1)
        {
            leftWall.transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
            rightWall.transform.Translate(-speed * Time.deltaTime, 0, -speed * Time.deltaTime);
        }

        if (!check2)
        {
            upRot.transform.Translate(0, 0, -speed * Time.deltaTime);
            downRot.transform.Translate(0, 0, speed * Time.deltaTime);
        }

        if (check1 && check2)
        {
            upRot.transform.Rotate(0, rotSpeed * Time.deltaTime,0);
            downRot.transform.Rotate(0,rotSpeed * Time.deltaTime,0);
        }
        
    }
}

