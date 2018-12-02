using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBarEventHandler : MonoBehaviour {
   public Text selectionTitle;
    public GameObject scrollViewPlayer;
    public GameObject scrollViewAbility;
    public GameObject scrollViewUnits;
    private Vector3 panelPlayerPosition, panelAbilityPosition, panelUnitsPosition;
    private Vector3 mainBasePosition;
    private Vector3 mainToLeftPosition;

    // Use this for initialization
    void Start () {
        mainBasePosition = scrollViewPlayer.transform.position;
        mainToLeftPosition = new Vector3(-65,1.6f,90);

        panelPlayerPosition = scrollViewPlayer.transform.position;
        panelAbilityPosition = scrollViewAbility.transform.position;
        panelUnitsPosition = scrollViewUnits.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonSelection(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                //Debug.Log("1");
                Debug.Log(scrollViewPlayer.transform.position);
                //Debug.Log("");
                scrollViewPlayer.transform.position = panelPlayerPosition;
                scrollViewAbility.transform.position = panelAbilityPosition;
                scrollViewUnits.transform.position = panelUnitsPosition;
                selectionTitle.text = "Player";
                break;
            case 2:
                Debug.Log("2");
                Debug.Log(scrollViewAbility.transform.position);

                scrollViewPlayer.transform.position = mainToLeftPosition;
                scrollViewAbility.transform.position = mainBasePosition;
                scrollViewUnits.transform.position = panelUnitsPosition;

                selectionTitle.text = "Ability's";
                break;
            case 3:
                Debug.Log("3");
                Debug.Log(scrollViewUnits.transform.position);

                scrollViewPlayer.transform.position = mainToLeftPosition;
                scrollViewAbility.transform.position = panelAbilityPosition;
                scrollViewUnits.transform.position = mainBasePosition;

                selectionTitle.text = "Units";
                break;
            default:
                break;
        }
        //Debug.Log("succes");
    }
}
