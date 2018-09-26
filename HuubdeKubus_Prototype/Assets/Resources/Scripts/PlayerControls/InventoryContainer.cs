using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

[XmlRoot("InventoryCollection")]
public class InventoryContainer {
    [XmlArray("Inventories")]
    [XmlArrayItem("Inventory")]
    public List<InventoryData> inventories = new List<InventoryData>();
}
