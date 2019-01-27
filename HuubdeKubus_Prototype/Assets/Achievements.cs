using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour {
    public static int explodedbarrels = 0;
    static bool BoomAchievement = false;
    static bool TacticianAchievement = false;
    bool gotMineBehaviour = false;

	// Use this for initialization
	void Start () {
        explodedbarrels = 0;
        if (this.GetComponent<MineBehaviour>() != null)
            this.gotMineBehaviour = true;

    }
	
	// Update is called once per frame
	void Update () {
		if(explodedbarrels >=5 && !BoomAchievement)
        {
            BoomAchievement = true;
            activateAchievement("BOOM!", "CgkIxPu6y84TEAIQBQ");
        }
	}

    void activateAchievement(string achievementText, string achievementId)
    {
        ShowAchievement.showAchievement(achievementText);
        MainMenuEvents.UnlockAchievement(achievementId);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.gotMineBehaviour && other.gameObject.name == "PlayerSphere")
        {
            explodedbarrels++;
        }

        if (this.name == "Star2" && other.gameObject.name == "PlayerSphere" && !TacticianAchievement)
        {
            TacticianAchievement = true;
            activateAchievement("Tactician", "CgkIxPu6y84TEAIQCg");
        }
    }
}
