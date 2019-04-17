using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CameraManager : MonoBehaviour {

    Pause pauseScript;
    Levels _levels;
    CameraSlerp camSlerp;
    CameraBehaviour camScript;

    public bool slerpOn;

    // Use this for initialization
    void Start () {

        camSlerp = this.gameObject.GetComponent<CameraSlerp>();
        camScript = this.gameObject.GetComponent<CameraBehaviour>();

        _levels = GameObject.Find("EventSystem").GetComponent<Levels>();
        pauseScript = GameObject.Find("EventSystem").GetComponent<Pause>();

        CameraSlerp.onStateChange += SlerpStateChanged;
        CameraSlerp.onSlerpFinished += SlerpFinished;

        if (slerpOn == true)
        {
            camSlerp.enabled = true;
        }
        else
        {
            camScript.enabled = true;
        }
    }

    void SlerpStateChanged(int state, Vector3 position)
    {
        if (state > 2)
        {
            StartCoroutine(PlaceParticles("StarParticles", position));
        }
    }

    void SlerpFinished()
    {
        if (!camScript || !camSlerp)
        {
            Debug.Log("camscript/slerp not found");

            camScript = this.gameObject.GetComponent<CameraBehaviour>();
            camSlerp = this.gameObject.GetComponent<CameraSlerp>();
            camScript.enabled = true;
            camSlerp.enabled = false;
        }
        else
        {
            camScript.enabled = true;
            camSlerp.enabled = false;
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
        CameraSlerp.onStateChange -= SlerpStateChanged;
    }
}
