using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    Pause pause;
    public GameObject explosion;
    
    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }
    
    void FixedUpdate()
    {
        if (gameObject.transform.position.z > 1.75)
        {
            GameObject.Instantiate(explosion);
            pause.DoDie();
        }
    }
}
