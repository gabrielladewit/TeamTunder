using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rb;

    private PickupBehaviour pickupManager;
    public GameObject replacement;

    public bool inverted = false;
    public float movementSpeed = 4;
    public int breakAmount = 0;
    // Use this for initialization
    void Start()
    {
        movementSpeed = 4;
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
