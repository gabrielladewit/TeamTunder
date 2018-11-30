using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public class SaveLevelScore : MonoBehaviour {

    public int[] stars;
    public Levels level;
    public bool initialized = false;

    private string destination;

    // Use this for initialization
    void Awake () {
        //LOAD STARS
        stars = new int[20];
        StartLoadThread();
    }

    public void SetLevelStars()
    {
        Debug.Log("Setting  -  Level: " + level.currentLevel + " Stars:" + level.currentStars);
        if (stars[level.currentLevel] < level.currentStars)
        {
            stars[level.currentLevel] = level.currentStars;
        }
        StartSaveThread();
    }

    public void StartSaveThread()
    {
        //saved = false;
        Thread thread = new Thread(SaveLevelStars);
        destination = Application.persistentDataPath + "/levelscores.dat";
        thread.Start();
    }

    public void SaveLevelStars()
    {
        // Get the path to the inventory
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, stars);
        file.Close();
    }

    public void StartLoadThread()
    {
        Thread thread = new Thread(LoadLevelStars);
        destination = Application.persistentDataPath + "/levelscores.dat";
        thread.Start();
    }

    public void LoadLevelStars()
    {
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            stars = new int[20];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = 0;
            }
            initialized = true;
            StartSaveThread();
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        stars = (int[])bf.Deserialize(file);
        Debug.Log("Saved Stars array length = " + stars.Length);
        file.Close();

        initialized = true;
    }

    public int[] GetStars()
    {
        return stars;
    }
}
