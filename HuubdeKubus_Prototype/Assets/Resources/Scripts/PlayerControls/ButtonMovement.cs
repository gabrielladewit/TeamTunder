using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    static bool isLeftPressed = false, isRightPressed = false;
    //private Rigidbody rigid;
    private ScoreUpdate scoreUpdateScript;
    private PickupScript pickupManager;
    bool invincible;
    bool moveFasterActive;
    public bool inverted = false;
    public float movementSpeed = 15;

    // Use this for initialization
    void Start()
    {
        pickupManager = GameObject.Find("Main Camera").GetComponent<PickupScript>();
      //StartCoroutine(MoveUpdate());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLeftPressed)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
            //this.gameObject.transform.Translate (new Vector3 (-movementSpeed/100, 0, 0));
        }

        //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

        if (isRightPressed)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
            //this.gameObject.transform.Translate (new Vector3 (movementSpeed/100, 0, 0));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pickup")
        {
            //Debug.Log("Kaaaaaaas!");
            pickupManager.CollissionInputChecker(this.gameObject, other.gameObject);
        }
    }

    void MoveUpdate()
    {
        while (true)
        {
            if (moveFasterActive)
            {
                movementSpeed = 200;
            }

            if (!inverted)
            {
                if (isLeftPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
                }

                //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

                if (isRightPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
                }

               // yield return new WaitForSeconds(0.1f);
            }
            else
            {
                if (isLeftPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
                }

                //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

                if (isRightPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
                }

                //yield return new WaitForSeconds(0.1f);
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
}
