using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficScenario : MonoBehaviour {

    public Levels level;
    private int currentLevel;

    public float counterAmount;
    private float counter;

    private int state;

    public int spawnLimit;
    public int spawnCount;

    private int currentPos;
    private bool spawnDriftCar;

    public GameObject player;
    public GameObject trafficCar;
    public GameObject driftCar;

    float[] spawnPointsX = new float[] { -12.9f, -5.6f, 5.6f, 12.9f }; //xpos
    float[] spawnPointsY = new float[] { 55.5f, -33.5f };            //ypos

    private List<float> usedPos = new List<float>();
    
    // Use this for initialization
    void Start () {
        level = GameObject.Find("UI").GetComponent<Levels>();
        player = GameObject.Find("PlayerSphere");

        currentLevel = level.currentLevel;
        state = 0;
        spawnDriftCar = true;

        FillList();

        counter = counterAmount;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentLevel == 2)
        {
            switch (state)
            {
                case 0:
                    SpawnMovingCars();
                    break;
                case 1:
                    //SpawnDriftCar();
                    break;
            }
        }
	}

    void SpawnDriftCar() {
        if (spawnDriftCar)
        {
            GameObject go = Instantiate(driftCar, player.transform.position, Quaternion.identity);
            spawnDriftCar = false;
        }
    }

    void SpawnMovingCars() {
        float checkedPos;

        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            currentPos = Random.Range(0, usedPos.Count());
            bool y = (Random.value > 0.5f);

            if (y)
            {
                checkedPos = usedPos[currentPos];

                if (usedPos.Contains(checkedPos))
                {
                    GameObject go = Instantiate(trafficCar, new Vector3(checkedPos, player.transform.position.y + spawnPointsY[0], player.transform.position.z), Quaternion.Euler(90, -90, 90));
                    go.GetComponent<TrafficCar>().up = true;
                    usedPos.Remove(checkedPos);
                }
            }
            else {
                checkedPos = usedPos[currentPos];

                if (usedPos.Contains(checkedPos))
                {
                    GameObject go = Instantiate(trafficCar, new Vector3(checkedPos, player.transform.position.y + spawnPointsY[1], player.transform.position.z), Quaternion.Euler(90, -90, 90));
                    go.GetComponent<TrafficCar>().up = false;
                    usedPos.Remove(checkedPos);
                }
            }

            if (usedPos.Count() <= 0)
            {
                FillList();
            }

            spawnCount++;
            counter = counterAmount;
        }

        if (spawnCount >= spawnLimit)
        {
            state++;
        }
    }

    void FillList()
    {
        for (int i = 0; i < spawnPointsX.Length; i++)
        {
            usedPos.Add(spawnPointsX[i]);
        }
    }
}
