using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandMenuItem : MonoBehaviour {
    private float standardHeight = 355.8f;
    private float standardWidth = 1402;

	// Use this for initialization
	void Start () {
        RectTransform rt = (RectTransform)this.transform;

        Debug.Log("Width: " + rt.rect.width + " Height: " + rt.rect.height);
    }

    public void ExpandField()
    {
        RectTransform rt = (RectTransform)this.transform;
        float oldHeight = rt.rect.height;
        float oldWidth = rt.rect.width;
        float newHeight = oldHeight + 240f;

        Debug.Log("Width: " + oldWidth + " Height: " + rt.rect.height);
        if (oldHeight <= standardHeight)
        {
            GameObject.Find("MoreButton1").GetComponentInChildren<Text>().text = "Less";
            rt.sizeDelta = new Vector2(standardWidth, newHeight);
            Image theImage = Resources.Load<Image>("ShowLess");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
