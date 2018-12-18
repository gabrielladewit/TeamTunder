using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    Pause pause;
    
    void Start()
    {
        pause = GameObject.Find("UI").GetComponent<Pause>();
    }
    
    void FixedUpdate()
    {
        if (gameObject.transform.position.z > 0)
        {
            if(pause != null)
                pause.DoDie();
        }
    }
}
