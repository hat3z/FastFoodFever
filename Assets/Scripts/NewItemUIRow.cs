using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewItemUIRow : MonoBehaviour
{

    public enum itemType { Appliance, Food, Drink, Ingredient};
    public itemType ItemType;

    string MyItemID = "null";

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQuantity;
    public TextMeshProUGUI ItemCost;
    public TextMeshProUGUI StoredAmount;
    public Button BuyButton;

    //Produce settings
    public Image ProduceImage;
    public TextMeshProUGUI produceName;

    public void SetMyItemID(string _itemID)
    {
        MyItemID = _itemID;
    }

    //public void SetupNewItemUI(object _itemObject)
    //{

    //}

    public void BuyItemButtonEvent()
    {
        ProfileController.Instance.AddItemToProfile(ItemDatabase.Instance.GetApplianceByID(MyItemID));
        BuildUIController.Instance.RefreshingBuildUIContent();
        BuildUIController.Instance.CloseNewItemPanel();
    }

    bool PlayerCanBuyItem(object _itemData)
    {
        if(_itemData is Appliance)
        {
            Appliance _item = (Appliance)_itemData;
            if(_item.costPrice <= ProfileController.Instance.PlayerMoney)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    #region Appliance Setup
    public void SetupAppliance(Appliance _applianceData)
    {
        SetMyItemID(_applianceData.applianceID);
        ItemImage.sprite = _applianceData.applianceImage;
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString();
        ProduceQuantity.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.costPrice.ToString();
        ProduceImage.sprite = ItemDatabase.Instance.GetFoodItemByID(_applianceData.produceID).foodImage;
        produceName.text = ItemDatabase.Instance.GetFoodItemByID(_applianceData.produceID).foodName;
        if(PlayerCanBuyItem(_applianceData))
        {
            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }
    }

    public void SetupFoodItem(FoodItem _foodData)
    {
        SetMyItemID(_foodData.foodID);

        ItemImage.sprite = _foodData.foodImage;
        ItemName.text = _foodData.foodName;
        Description.text = _foodData.description;

        if (PlayerCanBuyItem(_foodData))
        {
            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }
    }

    #endregion


}
