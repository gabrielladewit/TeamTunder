using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour {
    
    void OnBecameInvisible()
    {
        Debug.Log("THE PLAYER HAS DIED!!!");
        Application.Quit();
    }
}
