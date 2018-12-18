using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSpawner : MonoBehaviour {

    public GameObject pickup;
    float AmountOfPickups = 300;
    float count = 0;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < AmountOfPickups/10; i++)
        {
            for (int x = 0; x < AmountOfPickups / 5; x++)
            {
                Vector3 spawnPos = new Vector3(this.transform.position.x + 3 * count, this.transform.position.y - 3 * i, this.transform.position.z);
                GameObject go = (GameObject)Instantiate(pickup, this.transform);
                go.transform.position = spawnPos;
                count++;
            }
            count = 0;
        }
    }

    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
