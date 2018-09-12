using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject o_walls, o_turn, o_zigzag;

    private Vector3 wallsBegin = new Vector3(-25f, 1.5f, 5f);
    private Vector3 zigzagBegin = new Vector3(0, 1.5f, 74f);
    private Vector3 turnBegin = new Vector3(0, -1f, 0);

    public GameObject leftRot, rightRot, upRot, downRot;

    private Vector3 leftRotStart = new Vector3(-30,2,0);
    private Vector3 rightRotStart = new Vector3(30,2,0);
    private Vector3 upRotStart = new Vector3(0,2,22);
    private Vector3 downRotStart = new Vector3(0,2,-22);

    GameObject gunV1, gunV2, gunV3, gunH1, gunH2, gunH3;
    private float instantiateTimer = 6;
    public GameObject o_bullet;
    bool shoot = true;
    float timeShoot = 1f;
    int end = 0;

    public GameObject floor;

    float countDown = 12f;
    public int speed = 6;
    public int rotSpeed = 12;

    bool start = true;

    int scene = 0;

    // Use this for initialization
    void Start()
    {
        gunV1 = new GameObject("V1");
        gunV2 = new GameObject("V2");
        gunV3 = new GameObject("V3");
        gunH1 = new GameObject("H1");
        gunH2 = new GameObject("H2");
        gunH3 = new GameObject("H3");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            case 3:
                Bullet();
                break;
            case 4:
                MovingWall();
                break;
        }
    }

    public void Walls()
    {

        if (start)
        {
            o_walls.transform.position = wallsBegin;
            start = false;
        }

        if (!start)
        {
            o_walls.transform.Translate(speed * Time.deltaTime, 0, 0);

            if (o_walls.transform.position.x >= 104f)
            {
                scene++;
                start = true;
            }
        }
    }

    public void ZigZag()
    {
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

    public void Turn()
    {

        bool check1 = false;
        bool check2 = false;

        if (start)
        {
            leftRot.transform.position = leftRotStart;
            rightRot.transform.position = rightRotStart;
            upRot.transform.position = upRotStart;
            downRot.transform.position = downRotStart;
            start = false;
        }

        if (!start)
        {
            {
                if (upRot.transform.position.z <= 10f)
                {
                    check1 = true;
                }

                if (leftRot.transform.position.x >= -17f)
                {
                    check2 = true;
                }

                if (!check1)
                {
                    upRot.transform.Translate(0, 0, -speed * Time.deltaTime);
                    downRot.transform.Translate(0, 0, speed * Time.deltaTime);
                }

                if (!check2)
                {
                    leftRot.transform.Translate(speed * Time.deltaTime, 0, 0);
                    rightRot.transform.Translate(-speed * Time.deltaTime, 0, 0);
                }

                if (check1 && check2)
                {
                    upRot.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
                    downRot.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
                    leftRot.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
                    rightRot.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);

                    countDown -= Time.deltaTime;
                }

                if (countDown <= 0f)
                {
                    upRot.transform.position += Vector3.forward * speed;
                    downRot.transform.position += Vector3.forward * -speed;
                    leftRot.transform.position += Vector3.right * -speed;
                    rightRot.transform.position += Vector3.right * speed;

                    if (upRot.transform.position.z >= 22)
                    {
                        Debug.Log("hit");
                        check1 = true;
                        check2 = true;
                        countDown = 10f;
                        scene++;
                        start = true;
                    }
                }
            }
        }
    }

    public void Bullet()
    {
        float PosX = floor.transform.position.x;
        float PosY = floor.transform.position.z;

        float SizeX = floor.transform.localScale.x;
        float SizeY = floor.transform.localScale.z;

        float bulletHeight = 1.5f;

        float speedBullet = 250;

        if (start)
        {
            gunV1.transform.position = new Vector3(PosX - ((SizeX / 2) / 2), bulletHeight, PosY + (SizeY / 2));
            gunV2.transform.position = new Vector3(PosX, bulletHeight, PosY - (SizeY / 2));
            gunV3.transform.position = new Vector3(PosX + ((SizeX / 2) / 2), bulletHeight, PosY + (SizeY / 2));

            gunH1.transform.position = new Vector3(PosX - (SizeX / 2), bulletHeight, PosY + ((SizeY / 2) / 2));
            gunH2.transform.position = new Vector3(PosX + (SizeX / 2), bulletHeight, PosY);
            gunH3.transform.position = new Vector3(PosX - (SizeX / 2), bulletHeight, PosY - ((SizeY / 2) / 2));

            end = 0;
            start = false;
        }


        if (!start)
        {
            instantiateTimer -= Time.deltaTime;

            GameObject clone;

            if (!shoot)
            {
                timeShoot -= Time.deltaTime;
                if (timeShoot <= 0f)
                {
                    shoot = true;
                }

            }
            switch ((int)instantiateTimer)
            {
                case 6:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunV1.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.back * speedBullet);
                        timeShoot = 1f;
                        shoot = false;
                    }
                    break;
                case 5:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunH2.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.left * speedBullet);
                        timeShoot = 1f;
                        shoot = false;
                    }
                    break;
                case 4:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunH3.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.right * speedBullet);
                        timeShoot = 1f;
                        shoot = false;
                    }
                    break;
                case 3:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunV2.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * speedBullet);
                        timeShoot = 1f;
                        shoot = false;
                    }
                    break;
                case 2:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunV3.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.back * speedBullet);
                        timeShoot = 1f;
                        shoot = false;
                    }
                    break;
                case 1:
                    if (shoot)
                    {
                        clone = Instantiate(o_bullet, gunH1.transform.position, transform.rotation);
                        clone.GetComponent<Rigidbody>().AddForce(Vector3.right * speedBullet);
                        timeShoot = 1f;
                        instantiateTimer = 7;
                        end++;
                        shoot = false;
                    }
                    break;
            }
            if (end >= 3)
            {
                scene++;
                start = true;
            }
        }
    }

    public void MovingWall() {

    }
}

