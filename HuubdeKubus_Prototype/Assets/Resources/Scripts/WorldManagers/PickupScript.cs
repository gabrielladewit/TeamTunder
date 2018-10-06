using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    bool multiplierActive = false;
    bool invincibleActive = false;
    bool extraPlayerActive = false;
    bool moveFasterActive = false;
    bool changeSizeActive = false;

    GameObject playerObj;
    static bool ignoringCollision = true;
    bool timerActive = false;
    //bool triggered = false;
    float timer = 0f;
    AudioSource theSound;
    GameObject player2 = null;

    // Use this for initialization
    void Start()
    {
        theSound = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            Debug.Log(timer.ToString());
            if (timer > 5f)
            {
                SwitchCollision();
                timer = 0f;
                timerActive = false;

            }
        }
    }

    public void CollissionInputChecker(GameObject playerBall, GameObject pickup)
    {
        switch (pickup.gameObject.tag)
        {
            case "Invincible":
                {
                    Debug.Log("PICKUP: INVINCIBLE");
                    SwitchCollision();
                    timerActive = true;
                    invincibleActive = true;
                    pickup.transform.position = new Vector3(100, 100, 100);
                    Destroy(pickup.gameObject);
                    theSound.Play();
                    return;
                }
            case "Multiplier":
                {
                    Debug.Log("PICKUP: MULTIPLIER");
                    ScoreUpdate scoreUpdateScript = GameObject.Find("EventSystem").GetComponent<ScoreUpdate>();
                    scoreUpdateScript.multiplier = true;
                    Destroy(pickup.gameObject);
                    Debug.Log("Destroy: " + pickup.gameObject.name);
                    theSound.Play();
                    return;
                }
            case "Coin":
                {
                    Debug.Log("PICKUP: COIN");
                    Destroy(pickup.gameObject);
                    theSound.Play();
                    // Add code for coin pickup here
                    // Coin value not yet implemented. Store has to be done first.
                    // *Ready for implementation*

                    return;
                }
            case "ExtraPlayer":
                {
                    Debug.Log("PICKUP: SPAWN EXTRA BALL");
                    Destroy(pickup.gameObject);

                    if (extraPlayerActive == false)
                    {
                        extraPlayerActive = true;
                        player2 = Instantiate(Resources.Load("Prefabs/Player2") as GameObject, new Vector3(playerBall.transform.position.x + 2, playerBall.transform.position.y + 2, playerBall.transform.position.z), Quaternion.identity);
                        theSound.Play();
                    }
                    return;
                }
            case "ChangeSize":
                {
                    Debug.Log("PICKUP: CHANGE PLAYER SIZE");
                    playerBall.gameObject.transform.localScale += new Vector3(0.5F, 0.5f, 0.5f);
                    playerBall.GetComponent<Rigidbody>().mass = 2f;
                    Destroy(pickup.gameObject);
                    theSound.Play();
                    return;
                }
            case "MoveFaster":
                {
                    Debug.Log("PICKUP: MOVE PLAYER FASTER");
                    Destroy(pickup.gameObject);
                    theSound.Play();
                    return;
                }
            case "Invert":
                {
                    Debug.Log("PICKUP: INVERT");

                    ButtonMovement buttonMovementScript = playerBall.GetComponent<ButtonMovement>();
                    buttonMovementScript.inverted = true;

                    Destroy(pickup.gameObject);
                    theSound.Play();

                    return;
                }
            default:
                {
                    Debug.Log("Found object TAG nog implemented in switch case");
                    throw new Exception();
                }

        }
    }

    void SwitchCollision()
    {
        Debug.Log("Switch Collision");
        Physics.IgnoreLayerCollision(0, 9, ignoringCollision);
        ignoringCollision = !ignoringCollision;
    }
}
