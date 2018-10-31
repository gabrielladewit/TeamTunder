using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    GameObject playerObj;
    static bool ignoringCollision = true;
    AudioSource theSound;

    PlayerController playerController;
    int SecondsToWait = 0;
    ScoreUpdate scoreUpdate;

    // Use this for initialization
    void Start()
    {
        scoreUpdate = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
        playerObj = GameObject.Find("PlayerSphere");
        playerController = playerObj.GetComponent<PlayerController>();
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
        playerController.breakAmount += 1;
        Debug.Log(playerController.breakAmount);
    }

    void MoveFaster()
    {
        SecondsToWait = 5;
        playerController.movementSpeed = (playerController.movementSpeed == 7) ? 4 : 7;
    }

    void Coin()
    {
        SecondsToWait = 0;
        //Add coin
    }


    void Invert()
    {
        SecondsToWait = 5;
        playerController.inverted = !playerController.inverted;
    }

    void SwitchCollision()
    {
        // Debug.Log("Switch Collision");
            Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
            ignoringCollision = !ignoringCollision;
    }
}
