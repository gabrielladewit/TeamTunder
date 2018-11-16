using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UnityEngine;

public class SaveInventory : MonoBehaviour
{
    public int currentMoney, currentLives;
    public bool currentBoughtHeavy;
    public bool initialized = false;
    //public bool loaded = false, saved = false;
    private string destination;


    // Use this for initialization
    void Start () {
        //StartSaveThread();
        StartLoadThread();
	}

    public void StartSaveThread()
    {
        //saved = false;
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
        //saved = true;
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
        
        currentMoney = data.money;
        currentLives = data.lives;
        currentBoughtHeavy = data.boughtHeavy;
        initialized = true;
    }
	
    public void SpendMoney(int price)
    {
        currentMoney -= price;
        SaveFile();
    }

    public void AddLife()
    {
        currentLives++;
        SaveFile();
    }

    public void SetBoughtHeavy()
    {
        currentBoughtHeavy = true;
        SaveFile();
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
