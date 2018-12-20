using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    private AudioSource theSound;
    private Levels currentLevelStats;
    private PlayerController playerController;
    private ScoreUpdate scoreUpdate;

    static bool ignoringCollision = true;

    private int secondsToWait = 0;
    private float fasterSpeed = 7;
    private float normalSpeed = 4;

    // Use this for initialization
    void Start()
    {
        playerController = GameObject.Find("PlayerSphere").GetComponent<PlayerController>();
        scoreUpdate = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
        currentLevelStats = GameObject.Find("UI").GetComponent<Levels>();

        theSound = this.gameObject.GetComponent<AudioSource>();
    }

   public void StartPickup(string Method)
    {
        StartCoroutine(ResetPowerup(Method));
        theSound.Play();
    }

    IEnumerator ResetPowerup(string Method)
    {
        Invoke(Method, 0f);
        //Wacht 0.01 seconden zodat de methode de secondsToWait kan aanpassen.
        //secondsToWait wordt gebruikt zodat methodes zichzelf aan en uit kunnen zetten. Coin hoeft bijvoorbeeld niet nog een keer uitgevoerd te worden maar Multiplier wel.
        yield return new WaitForSeconds(0.01f);

        yield return new WaitForSeconds(secondsToWait);
        if (secondsToWait > 0)
        {
            Invoke(Method, 0f);
        }
    }

    void Multiplier()
    {
        secondsToWait = 5;
        scoreUpdate.multiplier = !scoreUpdate.multiplier;
    }

    void Breakable()
    {
        secondsToWait = 0;
        playerController.breakAmount += 1;
        Debug.Log(playerController.breakAmount);
    }

    void MoveFaster()
    {
        secondsToWait = 5;
        playerController.movementSpeed = (playerController.movementSpeed == fasterSpeed) ? normalSpeed : fasterSpeed;
    }

    void Coin()
    {
        secondsToWait = 0;
        if (!scoreUpdate.multiplier)
        {
            currentLevelStats.currentCoins += 10;
        }
        else
        {
            currentLevelStats.currentCoins += 20;
        }
    }


    void Invert()
    {
        secondsToWait = 5;
        playerController.inverted = !playerController.inverted;
    }

    void SwitchCollision()
    {
        // Debug.Log("Switch Collision");
            Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
            ignoringCollision = !ignoringCollision;
    }
}
