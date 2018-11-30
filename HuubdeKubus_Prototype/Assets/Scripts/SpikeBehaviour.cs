using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour {

    GameObject UI;
    Pause pause;
    PlayAudioClip audioClipPlayer;

    // Use this for initialization
    void Start () {
        UI = GameObject.Find("UI");
        pause = UI.GetComponent<Pause>();
        audioClipPlayer = UI.GetComponent<PlayAudioClip>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("spike HIttt");
        if (other.gameObject.name == "PlayerSphere")
        {
            Debug.Log("spike hittt");
            audioClipPlayer.PlayDamageSound();
            pause.DoDie();
        }
    }
}
