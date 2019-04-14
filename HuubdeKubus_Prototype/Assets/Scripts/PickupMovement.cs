using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PickupMovement : MonoBehaviour
{
    static PickupBehaviour pUp;
    //public ParticleSystem starParticles;
    Collider col;
    Levels lvlScript;
    CameraSlerp slerpScript;
    //public GameObject particles;
    //ObjectPool poolScript;
    bool on = false;

    private void Start()
    {
        pUp = GameObject.Find("PickupHandler").GetComponent<PickupBehaviour>();
        col = gameObject.GetComponent<Collider>();
        lvlScript = GameObject.Find("UI").GetComponent<Levels>();
        slerpScript = GameObject.Find("Main Camera Parent").GetComponent<CameraSlerp>();
    }

    public void Update()
    {
        /*if (timer == true)
        {
            //Debug.Log("timerrrr");

            time += Time.deltaTime;
        }
        if (time > 2f)
        {
            timer = false;
            time = 0;
            Debug.Log("timer");
            particles.SetActive(false);
            
        }*/

    }

    public enum Powerups
    {
        Multiplier,
        Breakable,
        MoveFaster,
        Coin,
        Invert,
        Star
    }

    public Powerups powerup;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "PlayerSphere")
        {
            pUp.Pickup(powerup.ToString());
            if (powerup.ToString() == "Star")
            {
                //StartCoroutine(ObjectPool.SharedInstance.PlaceParticles("StarParticles", this.transform.position, time));
                StartCoroutine(PlaceParticles("StarParticles"));
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    /*IEnumerator StarPickup()
    {
        GameObject starParticles = ObjectPool.SharedInstance.GetPooledObject("StarParticles");
        string tag = "StarParticles";

        if (starParticles != null)
        {
            starParticles.transform.position = this.transform.position;
            starParticles.transform.rotation = this.transform.rotation;
            starParticles.SetActive(true);
            starParticles.GetComponent<ParticleSystem>().Play();
        }

        col.enabled = !col.enabled;
        yield return new WaitForSeconds(1);
        //starParticles.GetComponent<ParticleSystem>().Clear();
        starParticles.SetActive(false);



        //ObjectPoolHandler.SharedInstance.GetObjectFromPool("StarParticles", this.transform.position, this.transform.rotation);
     
    }*/

    public IEnumerator PlaceParticles(string tag)
    {
        GameObject particles = ObjectPool.SharedInstance.GetPooledObject(tag);

        if (particles != null && on == false)
        {
            particles.transform.position = this.transform.position;
            particles.transform.rotation = this.transform.rotation;
            particles.SetActive(true);
            particles.GetComponent<ParticleSystem>().Play();
            on = true;
        }

        if (on == true)
        {
            yield return new WaitForSeconds(2f);

            //particles.GetComponent<ParticleSystem>().Clear();
            particles.SetActive(false);
            on = false;
        }
    }
}
