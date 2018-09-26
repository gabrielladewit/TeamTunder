using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public InventoryData inventoryData = new InventoryData();

    public string inventoryname = "inventory";

    public int money = 1000, lives = 0;
    public bool heavyBought = false;

	void StoreData()
    {

        inventoryData.money = money;
        inventoryData.lives = lives;
    }
	
	// Update is called once per frame
	void LoadData()
    {
        inventoryname = inventoryData.inventoryname;
        money = inventoryData.money;
        lives = inventoryData.lives;
        heavyBought = inventoryData.heavyBought;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}

public class InventoryData
{
    [XmlAttribute("Inventory")]
    public string inventoryname;

    [XmlElement("Money")]
    public int money;

    [XmlElement("Lives")]
    public int lives;

    [XmlElement("BoughtHeavy")]
    public bool heavyBought;
}
