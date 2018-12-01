using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    GameObject playerObj;
    static bool ignoringCollision = true;

    PlayerController playerController;
    int SecondsToWait = 0;
    ScoreUpdate scoreUpdate;
    Levels currentLevelStats;
    DisplayStars starScore;

    PlayAudioClip audioClipPlayer;

    // Use this for initialization
    void Start()
    {
        scoreUpdate = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
        starScore = GameObject.Find("EventSystem").GetComponent<DisplayStars>();
        playerObj = GameObject.Find("PlayerSphere");
        currentLevelStats = GameObject.Find("UI").GetComponent<Levels>();
        playerController = playerObj.GetComponent<PlayerController>();
        audioClipPlayer = GameObject.Find("UI").GetComponent<PlayAudioClip>();
    }

   public void Pickup(string Method)
    {
        StartCoroutine(ResetPowerup(Method));
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
        if (scoreUpdate.multiplier == false)
        {
            audioClipPlayer.PlayMultiplierSound(true);
        } else
        {
            audioClipPlayer.PlayMultiplierSound(false);
        }
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
        audioClipPlayer.PlayCoinSound();
        if (!scoreUpdate.multiplier)
        {
            currentLevelStats.currentCoins += 10;
        } else
        {
            currentLevelStats.currentCoins += 20;
        }
        //Add coin
    }

    void Invert()
    {
        SecondsToWait = 5;
        playerController.inverted = !playerController.inverted;
    }

    void Star()
    {
        SecondsToWait = 0;
        audioClipPlayer.PlayStarSound();
        currentLevelStats.currentStars++;
        starScore.starsToDisplay = currentLevelStats.currentStars;
        starScore.ChangeStars();
    }

    void SwitchCollision()
    {
        // Debug.Log("Switch Collision");
            Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
            ignoringCollision = !ignoringCollision;
    }
}
