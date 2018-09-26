using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour {

    public const string inventoryPath = "prefabs/inventory";
    private static string dataPath = string.Empty;

	void Awake () {
        if (Application.platform)
        {
            dataPath = System.IO.Path.Combine(Application.dataPath, "Resources/inventory.xml");
        }
	}
	
	public static CreateInventory(string path, int money, int lives, bool boughtHeavy)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        GameObject x = GameObject.Instantiate(prefab, );

        GameObject inventory;

        return inventory;
    }
}
