using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip starSound, coinSound, multiOnSound, multiOffSound;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	public void PlayStarSound()
    {
        audioSource.PlayOneShot(starSound);
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(starSound);
    }

    public void PlayMultiplierSound(bool turningOn)
    {
        if (turningOn)
        {
            audioSource.PlayOneShot(multiOnSound);
        } else
        {
            audioSource.PlayOneShot(multiOffSound);
        }
    }

    public void PlayDamageSound()
    {

    }
}
