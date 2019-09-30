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

    public void BuyItemButtonEvent(string _refreshContentString)
    {
        switch (_refreshContentString)
        {
            case "appliance":
                ProfileController.Instance.AddItemToProfile(ItemDatabase.Instance.GetApplianceByID(MyItemID));
                ShopUIController.Instance.RefreshingBuildUIContent(_refreshContentString);
                break;
            case "ingredient":
                ProfileController.Instance.AddItemToProfile(ItemDatabase.Instance.GetFoodIngredientByID(MyItemID));
                ShopUIController.Instance.RefreshingBuildUIContent(_refreshContentString);
                break;
            default:
                break;
        }

        ShopUIController.Instance.CloseNewItemPanel();
        ProfileController.Instance.SavePlayerProfileToFile();
    }

    bool PlayerCanBuyItem(object _itemData)
    {
        if(_itemData is Appliance)
        {
            Appliance _item = (Appliance)_itemData;
            if(_item.costPrice <= ProfileController.Instance.playerProfile.PlayerMoney)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if(_itemData is FoodIngredients)
        {
            FoodIngredients ing = (FoodIngredients)_itemData;
            if(ing.CostPrice <= ProfileController.Instance.playerProfile.PlayerMoney)
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
        ItemImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(_applianceData.applianceImagePath);
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString();
        ProduceQuantity.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.costPrice.ToString();
        ProduceImage.sprite =ItemDatabase.Instance.GetSpriteFromPath(ItemDatabase.Instance.GetFoodItemByID(_applianceData.produceID).foodImagePath);
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

    #endregion

    #region Ingredient Setup

    public void SetupIngredient(FoodIngredients _ingData)
    {
        SetMyItemID(_ingData.IngredientID);

        ItemImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(_ingData.IngredientImagePath);
        ItemName.text = _ingData.IngredientName;
        ItemCost.text = _ingData.CostPrice.ToString();
        //Description.text = _ingData.de;

        if (PlayerCanBuyItem(_ingData))
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
