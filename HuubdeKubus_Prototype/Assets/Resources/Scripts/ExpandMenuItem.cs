using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandMenuItem : MonoBehaviour {
    private float standardHeight = 292.9f;
    private float standardWidth = 1422f;

	// Use this for initialization
	void Start () {
		
	}

    public void ExpandField()
    {
        RectTransform rt = (RectTransform)this.transform;
        float oldHeight = rt.rect.height;
        float oldWidth = rt.rect.width;
        float newHeight = oldHeight + 240f;

        Debug.Log("Width: " + oldWidth + " Height: " + rt.rect.height);

        rt.sizeDelta = new Vector2(standardWidth, newHeight);
        Button theButton = GameObject.Find("btMore").GetComponent<Button>();
        Sprite theImage = Resources.Load<Sprite>("ShowLess");

        //theButton.GetComponent<Image>().overrideSprite = theImage;
        theButton.image.sprite = theImage;


        Debug.Log("Width: " + rt.rect.width);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
