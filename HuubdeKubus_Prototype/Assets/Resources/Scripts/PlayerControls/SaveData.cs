using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveData
{

    public static InventoryContainer invContainer = new InventoryContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void Load(string path)
    {
        invContainer = LoadInventory(path);

        foreach (InventoryData data in invContainer.inventories)
        {

        }
    }

    public static void Save(string path, InventoryContainer container)
    {

    }

    public static void AddInventoryData(InventoryData data)
    {
        invContainer.inventories.Add(data);
    }

    public static void ClearInventory()
    {
        invContainer.inventories.Clear();
    }

    private static InventoryContainer LoadInventory(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(InventoryContainer));

        FileStream stream = new FileStream(path, FileMode.Truncate);

        InventoryContainer container = serializer.Deserialize(stream) as InventoryContainer;

        stream.Close();

        return container;
    }

    private static void SaveInventory(string path, InventoryContainer container)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(InventoryContainer));

        FileStream stream = new FileStream(path, FileMode.Truncate);

        serializer.Serialize(stream, container);

        stream.Close();
    }
}
