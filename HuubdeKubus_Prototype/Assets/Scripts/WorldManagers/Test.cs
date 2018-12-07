using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Levels currentLevelStats;
    
    void Start () {
        currentLevelStats = GameObject.Find("UI").GetComponent<Levels>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerSphere")
        {
            currentLevelStats.currentStars++;
        }
    }
}
