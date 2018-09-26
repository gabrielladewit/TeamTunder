using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveInventory : MonoBehaviour {
    
    string currentName = "Inventory";
    int currentMoney = 1234, currentLives = 2;
    bool currentBoughtHeavy = false;


	// Use this for initialization
	void Start () {
        LoadFile();
	}

    public void SaveFile()
    {
        // Get the path to the inventory
        string destination = Application.persistentDataPath + "/inventory.dat";
        FileStream file;
        
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
        
        Inventory data = new Inventory(currentMoney, currentLives, currentBoughtHeavy);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    void LoadFile()
    {
        string destination = Application.persistentDataPath + "/inventory.dat";
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
        
        Debug.Log(data.money);
        Debug.Log(data.lives);
        Debug.Log(data.boughtHeavy);
    }
	
    public void SetMoney(int price)
    {
        currentMoney -= price;
        SaveFile();
    }

    public void AddLives()
    {
        currentLives++;
        SaveFile();
    }

    public void SetBoughtHeavy()
    {
        currentMoney -= 100;
        currentBoughtHeavy = true;
        SaveFile();
    }
}
