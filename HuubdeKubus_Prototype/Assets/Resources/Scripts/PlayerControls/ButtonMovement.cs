using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    private bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rigid;
    private ScoreUpdate scoreUpdateScript;
    private bool invincible = false;

    // Use this for initialization
    void Start()
    {
        rigid = GameObject.Find("PlayerSphere").GetComponent<Rigidbody>();
        if (rigid != null)
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
        if (other.gameObject.CompareTag("Multiplier"))
        {
            //other.gameObject.SetActive(false);
            Debug.Log("Pickup: score multiplier");
            scoreUpdateScript = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
            scoreUpdateScript.multiplier = true;
            Destroy(other.gameObject);
            Debug.Log("Destroy: " + other.gameObject.name);
        }

        if (other.gameObject.CompareTag("Invincible"))
        {
            Debug.Log("PICKUP: INVINCIBLE");
            Destroy(other.gameObject);
            invincible = true;
        }

        //// Still working on the invincibility pickup!

        //if (other.gameObject.name.Contains("Right"))
        //{

        //    if (invincible == true)
        //    {
        //        Debug.Log("INVINCIBLE ACTIVE");
                
        //        Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>(), true);
        //        invincible = false;
        //    }

        //}


    }
    IEnumerator MoveUpdate()
    {
        while (true)
        {
            if (isLeftPressed)
            {
                rigid.AddForce(new Vector3(-50, 0, 0));
            }
                
            //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

            if (isRightPressed)
            {
                rigid.AddForce(new Vector3(50, 0, 0));
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
