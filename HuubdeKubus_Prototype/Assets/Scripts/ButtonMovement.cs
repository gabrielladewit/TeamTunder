using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    private bool isLeftPressed = false, isRightPressed = false;
    private Rigidbody rigid;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(MoveUpdate());
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveUpdate()
    {
        while (true)
        {
            if (isLeftPressed)
                rigid.AddForce(new Vector3(-50, 0, 0));
            //this.gameObject.transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);

            if (isRightPressed)
                rigid.AddForce(new Vector3(50, 0, 0));
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
