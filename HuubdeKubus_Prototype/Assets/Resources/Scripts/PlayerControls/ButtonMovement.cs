using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    private bool isLeftPressed = false, isRightPressed = false;
    //private Rigidbody rigid;
    private ScoreUpdate scoreUpdateScript;
    private PickupScript pickupScript;
    bool invincible;
    bool moveFasterActive;
    public bool inverted = false;
    private float movementSpeed = 50;

    // Use this for initialization
    void Start()
    {
        pickupScript = GameObject.Find("Main Camera").GetComponent<PickupScript>();

        if (this.gameObject != null)
        {
            StartCoroutine(MoveUpdate());
        }
        else
        {
            Debug.Log("No player found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pickup")
        {
            //Debug.Log("Kaaaaaaas!");
            pickupScript.CollissionInputChecker(this.gameObject, other.gameObject);
        }
        //if (other.gameObject.CompareTag("Multiplier"))
        //{
        //    //other.gameObject.SetActive(false);
        //    Debug.Log("Pickup: score multiplier");
        //    scoreUpdateScript = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
        //    scoreUpdateScript.multiplier = true;
        //    Destroy(other.gameObject);
        //    Debug.Log("Destroy: " + other.gameObject.name);
        //}

        //if (other.gameObject.CompareTag("Invincible"))
        //{
        //    Debug.Log("PICKUP: INVINCIBLE");
        //    Destroy(other.gameObject);
        //    invincible = true;
        //}

        //if (other.gameObject.CompareTag("Coin"))
        //{
        //    Debug.Log("PICKUP: COIN");
        //    Destroy(other.gameObject);
        //    // Add code for coin pickup here

        //}

        //if (other.gameObject.CompareTag("ExtraBall"))
        //{
        //    Debug.Log("PICKUP: EXTRA BALL");
        //    Destroy(other.gameObject);
        //    // Add code for extra ball pickup here
        //    //GameObject extraPlayer = Instantiate(playerClone, transform.position, transform.rotation);

        //    //Instantiate(prefab, new Vector3(this.transform.position.x + 2, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);
        //    GameObject player2 = Instantiate(Resources.Load("Prefabs/Player2") as GameObject, new Vector3(this.transform.position.x + 2, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);

        //    //(GameObject)//GameObject theNippleKing = GameObject.Find("PlayerSphere(Clone)");

        //}
    }

    IEnumerator MoveUpdate()
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

                yield return new WaitForSeconds(0.1f);
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

                yield return new WaitForSeconds(0.1f);
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
