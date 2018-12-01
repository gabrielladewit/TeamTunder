using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rb;
    
    public GameObject replacement;

    public bool inverted = false;
    public float movementSpeed = 4;
    public int breakAmount = 0;

    public Stopwatch stopwatch;
    public PickupBehaviour pickupManager;
    
    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        movementSpeed = 6;
        rb = this.gameObject.GetComponent<Rigidbody>();
        pickupManager = GameObject.Find("PickupHandler").GetComponent<PickupBehaviour>();
    }
    
    void FixedUpdate()
    {
        MoveUpdate();
    }
    
    void MoveUpdate()
    {
        if (!inverted)
        {
            if (isLeftPressed)
            {
                if (rb.velocity.x > 3)
                {
                    rb.AddForce(new Vector3(-movementSpeed * 2, 0, 0));
                } else
                {
                    rb.AddForce(new Vector3(-movementSpeed, 0, 0));
                }
            }

            if (isRightPressed)
            {
                if (rb.velocity.x < -3)
                {
                    rb.AddForce(new Vector3(movementSpeed * 2, 0, 0));
                }
                else
                {
                    rb.AddForce(new Vector3(movementSpeed, 0, 0));
                }
            }
        }
        else
        {
            
            if (isLeftPressed)
            {
                rb.AddForce(new Vector3(movementSpeed, 0, 0));
            }

            if (isRightPressed)
            {
                rb.AddForce(new Vector3(-movementSpeed, 0, 0));
            }
        }
    }

    public void OnPointerDownLeftButton()
    {
        isLeftPressed = true;
    }

    public void OnPointerUpLeftButton()
    {
        isLeftPressed = false;
    }

    public void OnPointerDownRightButton()
    {
        isRightPressed = true;
    }

    public void OnPointerUpRightButton()
    {
        isRightPressed = false;
    }

    public void StopStopwatch()
    {
        Levels currentLevel = GameObject.Find("UI").GetComponent<Levels>();
        stopwatch.Stop();

        //TODO: Calculate bonus score !!
        int bonusScore = 100; // Mathf.RoundToInt((75*1000) - (int)stopwatch.ElapsedMilliseconds)/1000;
        currentLevel.currentCoins += bonusScore;

    }

    void SpawnBreakable(GameObject go)
    {
       GameObject breakable =  (GameObject)GameObject.Instantiate(replacement, go.transform.position, go.transform.rotation);
       Vector3 colliderScale = new Vector3(go.transform.localScale.x / 2, go.transform.localScale.y / 2, go.transform.localScale.z / 2);
       breakable.transform.localScale = colliderScale;

        Destroy(go.gameObject);
        breakAmount--;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (breakAmount > 0)
        {
            if (coll.gameObject.name != "Left" && coll.gameObject.name != "Right")
            {
                SpawnBreakable(coll.gameObject);
            }
        }
    }
}
