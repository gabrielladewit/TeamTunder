using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    GameObject playerObj;
    static bool ignoringCollision = true;
    AudioSource theSound;

    ButtonMovement buttonMovement;
    int SecondsToWait = 0;
    ScoreUpdate scoreUpdate;

    // Use this for initialization
    void Start()
    {
        scoreUpdate = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
        playerObj = GameObject.Find("PlayerSphere");
        buttonMovement = playerObj.GetComponent<ButtonMovement>();
        theSound = this.gameObject.GetComponent<AudioSource>();
    }

   public void Pickup(string Method)
    {
        StartCoroutine(ResetPowerup(Method));
        theSound.Play();
    }

    IEnumerator ResetPowerup(string Method)
    {
        Invoke(Method, 0f);
        yield return new WaitForSeconds(0.01f);

        yield return new WaitForSeconds(SecondsToWait);
        if (SecondsToWait > 0)
            Invoke(Method, 0f);
    }

    void Multiplier()
    {
        SecondsToWait = 5;
        scoreUpdate.multiplier = !scoreUpdate.multiplier;
    }

    void Breakable()
    {
        SecondsToWait = 0;
        buttonMovement.breakAmount += 1;
        Debug.Log(buttonMovement.breakAmount);
    }

    void MoveFaster()
    {
        SecondsToWait = 5;
        buttonMovement.movementSpeed = (buttonMovement.movementSpeed == 40) ? 15 : 40;
    }

    void Coin()
    {
        SecondsToWait = 0;
        //Add coin
    }


    void Invert()
    {
        SecondsToWait = 5;
        buttonMovement.inverted = !buttonMovement.inverted;
    }

    void SwitchCollision()
    {
        // Debug.Log("Switch Collision");
            Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
            ignoringCollision = !ignoringCollision;
    }
}
