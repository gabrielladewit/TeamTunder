using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAchievement : MonoBehaviour {

    public GameObject achievement;
    public static GameObject achievementDropdown;
    static Text achievementText;
    AudioSource achievementAudio;
    bool audioPlayed = false;
    float timer = 4f;
    static bool timing = false;
    string achievement1 = "";
	// Use this for initialization
	void Start () {
        achievementDropdown = achievement;
        achievementAudio = achievementDropdown.GetComponent<AudioSource>();
        achievementText = achievementDropdown.transform.GetChild(0).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timing)
            timer -= Time.deltaTime;

        if (timer <= 3.5f && !audioPlayed)
        {
            achievementAudio.Play();
            audioPlayed = true;
        }

        if (timer <= 0f)
            removeAchievement();

    }

    public static void showAchievement(string achievement)
    {
        timing = true;
        achievementDropdown.SetActive(true);
        achievementText.text = achievement;
    }

    public void removeAchievement()
    {
        timing = false;
        timer = 4f;
        audioPlayed = false;
        achievementDropdown.SetActive(false);
    }
}
