using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CameraManager : MonoBehaviour {

    CameraSlerp camSlerp;
    CameraBehaviour camScript;
    public bool slerpOn;
    public static event Action initiateGame;

    // Use this for initialization
    void Start () {
        camSlerp = this.gameObject.GetComponent<CameraSlerp>();
        camScript = this.gameObject.GetComponent<CameraBehaviour>();

        //Subscribe to the events
        CameraSlerp.onStateChange += SlerpStateChanged;
        CameraSlerp.onSlerpFinished += SlerpFinished;

        SlerpOnOff();
    }

    void SlerpStateChanged(int state, Vector3 position)
    {
        //Play particles at the position of each star that the slerp camera focuses on
        if (state > 1)
        {
            StartCoroutine(PlaceParticles("StarParticles", position));
        }
    }

    void SlerpFinished()
    {
        slerpOn = false;
        SlerpOnOff();
        initiateGame();
    }

    void SlerpOnOff()
    {
        if (camSlerp || camScript)
        {
            switch (slerpOn)
            {
                case true:
                    camSlerp.enabled = true;
                    camScript.enabled = false;
                    break;
                case false:
                    camSlerp.enabled = false;
                    camScript.enabled = true;
                    break;
            }
        }
        else
        {
            Debug.Log("Camera script(s) not found");
        }
    }

    //Places particlesystem at the specified position
    public IEnumerator PlaceParticles(string tag, Vector3 pos)
    {
        GameObject particles = ObjectPool.SharedInstance.GetPooledObject(tag);

        if (particles != null)
        {
            particles.transform.position = pos;
            particles.transform.rotation = this.transform.rotation;
            particles.SetActive(true);
            particles.GetComponent<ParticleSystem>().Play();
        }

        yield return new WaitForSeconds(2f);

        particles.SetActive(false);
    }

    private void OnDisable()
    {
        //Unsubscribe from events
        CameraSlerp.onStateChange -= SlerpStateChanged;
        CameraSlerp.onSlerpFinished -= SlerpFinished;
    }
}
