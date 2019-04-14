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

    public delegate void OnBoolChangeDelegate(bool value);
    public static event OnBoolChangeDelegate onBoolChange;

    private bool slerpFinish;
    private int slerpState;
    //public bool slerpFinish;

    // Use this for initialization
    void Start () {

        camSlerp = this.gameObject.GetComponent<CameraSlerp>();
        camScript = this.gameObject.GetComponent<CameraBehaviour>();

        _levels = GameObject.Find("EventSystem").GetComponent<Levels>();
        pauseScript = GameObject.Find("EventSystem").GetComponent<Pause>();

        if (slerpOn == true)
        {
            camSlerp.enabled = true;
        }
        else
        {
            camScript.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if (slerpFinish)
        {
            //Debug.Log("Cam manager on change");
           // onBoolChange(slerpFinish);
        }
	}

    public bool SlerpFinish
    {
        get
        {
            return slerpFinish;
        }
        set
        {
            slerpFinish = value;
            onBoolChange(slerpFinish);
            //Debug.Log("SLERPfin " + slerpFinish);
            //Debug.Log("boolchange " + onBoolChange);
        }
    }

    public int SlerpState
    {
        get
        {
            return slerpState;
        }
        set
        {
            if (slerpState != value)
            {
                slerpState = value;
                if (slerpState > 2)
                {
                    StartCoroutine(PlaceParticles("StarParticles", camSlerp.posA));
                }
            }
        }
    }

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
}
