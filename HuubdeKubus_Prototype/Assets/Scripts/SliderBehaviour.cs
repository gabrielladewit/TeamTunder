using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour {

    public Slider huubSlider;
    public Slider playerSlider;

    public GameObject Player;
    public GameObject Huub;

    private float mapLength;
    private Vector3 playerStartPos;
    private Vector3 huubStartPos;

	// Use this for initialization
	void Start () {
        playerStartPos = Player.transform.position;
        huubStartPos = Huub.transform.position;
        mapLength = -175;
	}
	
	// Update is called once per frame
	void Update () {
        TranslatePosition();
	}

    void TranslatePosition()
    {
        float playerPos = (Player.transform.position.y - playerStartPos.y) / mapLength;
        float huubPos = (Huub.transform.position.y - huubStartPos.y) / mapLength;

        
    
        playerSlider.value = playerPos;
        huubSlider.value = huubPos;
    }
}
