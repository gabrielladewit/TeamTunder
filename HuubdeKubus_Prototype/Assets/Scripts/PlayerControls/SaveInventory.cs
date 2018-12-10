using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public class SaveInventory : MonoBehaviour
{
    public int currentMoney, currentLives;
    public bool currentBoughtHeavy = false;
    public bool initialized = false;
    private string destination;

    Levels currentLevelStats;


    // Use this for initialization
    void Awake () {
        currentLevelStats = GameObject.Find("UI").GetComponent<Levels>();
        //StartSaveThread();
        StartLoadThread();
    }

    public void StartSaveThread()
    {
        Thread thread = new Thread(SaveFile);
        destination = Application.persistentDataPath + "/inventory.dat";
        thread.Start();
    }

    public void SaveFile()
    {
        // Get the path to the inventory
        FileStream file;
        
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        
        Inventory data = new Inventory(currentMoney, currentLives, currentBoughtHeavy);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void StartLoadThread()
    {
        //loaded = false;
        Thread thread = new Thread(LoadFile);
        destination = Application.persistentDataPath + "/inventory.dat";
        thread.Start();
    }

    public void LoadFile()
    {        
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Inventory data = (Inventory)bf.Deserialize(file);
        file.Close();
        
        currentMoney = data.coins;
        currentLives = data.lives;
        currentBoughtHeavy = data.boughtHeavy;
        initialized = true;
    }
	
    public void SpendMoney(int price)
    {
        currentMoney -= price;
        StartSaveThread();
    }

    public void AddCoins(int toAdd)
    {
        currentMoney += toAdd;
        StartSaveThread();
    }

    public void AddCoinsAfterGame()
    {
        Debug.Log("wejo te laat");
        currentMoney += currentLevelStats.currentCoins;
        StartSaveThread();
    }

    public void AddLife()
    {
        currentLives++;
        StartSaveThread();
    }

    public void SetBoughtHeavy()
    {
        currentBoughtHeavy = true;
        StartSaveThread();
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    public bool GetCurrentBoughtHeavy()
    {
        return currentBoughtHeavy;
    }
}
