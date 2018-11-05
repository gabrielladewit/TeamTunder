using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    private bool isLeftPressed = false, isRightPressed = false;
    // Use this for initialization
    ButtonMovement buttonMovementScript;
    void Start () {
        buttonMovementScript = GameObject.Find("PlayerSphere").GetComponent<ButtonMovement>();
        Debug.Log("Hi Kaas ement");
        StartCoroutine(MoveUpdate());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MoveUpdate()
    {
        Debug.Log("Hij komt in de movement");
        while (true)
        {
            if (!buttonMovementScript.inverted)
            {
                Debug.Log("Hij komt in niet inverted");
                if (isLeftPressed)
                {
                    Debug.Log(this.gameObject.name);
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-50, 0, 0));
                }

                
                //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

                if (isRightPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(50, 0, 0));
                }

                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                if (isLeftPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(50, 0, 0));
                }

                //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

                if (isRightPressed)
                {
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-50, 0, 0));
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
