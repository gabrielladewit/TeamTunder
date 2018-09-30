using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    private bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rigid;
    private ScoreUpdate scoreUpdateScript;

    private Transform prefab;

    // Use this for initialization
    void Start()
    {


        //if (prefab != null)
        //{
        //    //StartCoroutine(MoveUpdate());
        //}
        //else
        //{
        //    Debug.Log("No PLAYER2 found!");
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiplier"))
        {
            //other.gameObject.SetActive(false);
            Debug.Log("Pickup: score multiplier");
            scoreUpdateScript = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
            scoreUpdateScript.multiplier = true;
            Destroy(other.gameObject);
            Debug.Log("Destroy: " + other.gameObject.name);
        }
<<<<<<< HEAD

        if (other.gameObject.CompareTag("Invincible"))
        {
            Debug.Log("PICKUP: INVINCIBLE");
            Destroy(other.gameObject);
            invincible = true;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("PICKUP: COIN");
            Destroy(other.gameObject);
            // Add code for coin pickup here

        }

        if (other.gameObject.CompareTag("ExtraBall"))
        {
            Debug.Log("PICKUP: EXTRA BALL");
            Destroy(other.gameObject);
            // Add code for extra ball pickup here
            //GameObject extraPlayer = Instantiate(playerClone, transform.position, transform.rotation);

            //Instantiate(prefab, new Vector3(this.transform.position.x + 2, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);
             GameObject player2 = Instantiate (Resources.Load("Prefabs/Player2") as GameObject, new Vector3(this.transform.position.x + 2, this.transform.position.y + 2, this.transform.position.z), Quaternion.identity);

            //(GameObject)//GameObject theNippleKing = GameObject.Find("PlayerSphere(Clone)");

        }

        //// Still working on the invincibility pickup!
        // De obstacle names moeten aangepast worden. Anders kan ik geen collision detection doen.
        // Mogelijk kan ik ook een trigger detection doen. Daar moet ik nog even naar kijken.
        if (other.gameObject.name.Contains("ObstacleR"))
        {

            if (invincible == true)
            {
                Debug.Log("INVINCIBLE ACTIVE");

                Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
                invincible = false;
            }

        }
=======
>>>>>>> master
    }

    IEnumerator MoveUpdate()
    {
        while (true)
        {
            if (isLeftPressed)
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(-50, 0, 0));
            }

            if (isRightPressed)
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(50, 0, 0));
            }
                
            yield return new WaitForSeconds(0.1f);
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
