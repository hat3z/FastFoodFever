using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewItemUIRow : MonoBehaviour
{

    public enum itemType { Appliance, Food, Drink, Ingredient};
    public itemType ItemType;

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQuantity;
    public TextMeshProUGUI ItemCost;


    public void SetupAppliance(Appliance _applianceData)
    {
        ItemImage.sprite = _applianceData.applianceImage;
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString();
        ProduceQuantity.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.costPrice.ToString();
    }
}
