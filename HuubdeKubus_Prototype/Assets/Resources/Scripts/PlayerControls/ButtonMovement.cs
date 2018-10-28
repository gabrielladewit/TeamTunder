using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    static bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rb;
    private ScoreUpdate scoreUpdateScript;
    private PickupBehaviour pickupManager;
    bool invincible;
    bool moveFasterActive;
    public bool inverted = false;
    public float movementSpeed = 15;
    public int breakAmount = 0;
    // Use this for initialization
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        pickupManager = GameObject.Find("Main Camera").GetComponent<PickupBehaviour>();
        //StartCoroutine(MoveUpdate());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveUpdate();

    }


    void MoveUpdate()
    {
        if (moveFasterActive)
        {
            movementSpeed = 200;
        }

        if (!inverted)
        {
            if (isLeftPressed)
            {
                rb.AddForce(new Vector3(-movementSpeed, 0, 0));
            }

            if (isRightPressed)
            {
                rb.AddForce(new Vector3(movementSpeed, 0, 0));
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

    void OnCollisionEnter(Collision coll)
    {
        if (breakAmount > 0)
        {
            if (coll.gameObject.name != "Left" && coll.gameObject.name != "Right")
            {
                Destroy(coll.gameObject);
                breakAmount--;
            }
        }
    }
}
