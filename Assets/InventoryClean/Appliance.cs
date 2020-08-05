using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Appliance 
{
    public string applianceName;
    public string applianceID;
    public string modelPath;
    public string applianceImagePath;
    public string groupID;
    public enum tier { Low, Medium, High, Premium};
    public tier Tier;
    public float ProduceTime;
    public int ProduceQuantity;
    public int storedAmount;
    public int sellPrice;
    public int costPrice;
    public string produceID;
    public int DynamicTileID;
    public string ProfileHash;
    public Appliance MyClone()
    {
        Appliance newItem = new Appliance();
        newItem.applianceID = applianceID;
        newItem.applianceName = applianceName;
        newItem.modelPath = modelPath;
        newItem.applianceImagePath = applianceImagePath;
        newItem.groupID = groupID;
        newItem.Tier = Tier;
        newItem.ProduceTime = ProduceTime;
        newItem.ProduceQuantity = ProduceQuantity;
        newItem.storedAmount = storedAmount;
        newItem.sellPrice = sellPrice;
        newItem.costPrice = costPrice;
        newItem.produceID = produceID;
        return newItem;
    }

}
