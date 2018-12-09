using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCar : MonoBehaviour
{

    public int speed;
    public bool up;
    public int currentPosX;
    public int newPosX;

    private float t;
    private bool checkPos = true;
    public bool switchLane;

    public float counter;

    public GameObject player;

    float[] spawnPointsX = new float[] { -12.9f, -5.6f, 5.6f, 12.9f };
    float[] spawnPointsY = new float[] { 55.5f, -43.5f };

    void Start()
    {
        player = GameObject.Find("PlayerSphere");

        switchLane = (Random.value > 0.3f); // 70% chance

        if (!up)
        {
            counter = counter - (counter / 2);
        }

        CheckCurrentPos();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if (up)
        {
            this.transform.Translate(Vector3.forward * (speed + (speed * 2)) * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }

        //Switch lanes
        SwitchLanes();
        
        ObstacleDestroy(up);
    }

    void SwitchLanes()
    {
        if (switchLane)
        {
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                while (checkPos)
                {
                    if (currentPosX > 0 && currentPosX < 3)
                    {
                        int changedPos = RandomAddDecrease();
                        newPosX = changedPos;
                    }

                    if (currentPosX == 0)
                    {
                        int changedPos = currentPosX + 1;
                        newPosX = changedPos;
                    }

                    if (currentPosX == spawnPointsX.Length - 1)
                    {
                        int changedPos = currentPosX - 1;
                        newPosX = changedPos;
                    }
                    checkPos = false;
                }

                t += 0.5f * Time.deltaTime;

                transform.position = new Vector3(Mathf.Lerp(spawnPointsX[currentPosX], spawnPointsX[newPosX], t), transform.position.y, transform.position.z);
            }
        }
    }

    void CheckCurrentPos()
    {
        for (int i = 0; i < spawnPointsX.Length; i++)
        {
            if (transform.position.x == spawnPointsX[i])
            {
                currentPosX = i;
            }
        }
    }

    private int RandomAddDecrease() {
        bool a = (Random.value > 0.5f);
        if (a)
        {
            return currentPosX - 1;
        }
        else {
            return currentPosX + 1;
        }
    }

    void ObstacleDestroy(bool upDown) {
        if (upDown)
        {
            if (transform.position.y <= player.transform.position.y + spawnPointsY[1])
            {
                Destroy(this.gameObject);   
            }
        }
        else {
            if (transform.position.y >= player.transform.position.y + spawnPointsY[0])
            {
                Destroy(this.gameObject);
            }
        }
    }
}