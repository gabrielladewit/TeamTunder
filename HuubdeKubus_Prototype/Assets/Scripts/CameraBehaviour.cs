using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject playerT;
    private Vector3 camPos;

    private void Awake()
    {
       // CameraManager.onBoolChange += CameraInitiated;

    }

    private void OnEnable()
    {
        playerT = GameObject.Find("PlayerSphere");

        //Set camera rotation to rotation in CameraTesting32 Scene so that the transition is smooth
        transform.eulerAngles = new Vector3(-32.196f, 0, 0);
        camPos = new Vector3(0, -15f, -25f);
    }

    private void Update()
    {
        transform.position = playerT.transform.position + camPos;
    }
}

