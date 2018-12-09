using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    Pause pause;

    // Use this for initialization
    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
    }

    //Die when the player is not in the level
    public void OutOfBounds()
    {
        if (gameObject.transform.position.x < -100 || gameObject.transform.position.x > 100 || gameObject.transform.position.z > 2 || gameObject.transform.position.z < -400)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        pause.DoDie();
    }

    /*void OnBecameInvisible()
    {
        if (GameObject.Find("PlayerSphere") == null)
        {
            pause.DoDie();
        }
    }*/
}
