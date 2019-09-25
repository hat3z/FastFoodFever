using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIRow : MonoBehaviour
{
    public enum itemType { Appliance, Food, Drink, Ingredient };
    public itemType ItemType;

    string MyItemID;
    int myDynamicTileID;
    string MyApplianceHash;
    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQt;
    public TextMeshProUGUI ItemCost;
    public TextMeshProUGUI StoredAmount;

    public Button PlaceButton;
    public Button ReplaceButton;
    public Button SellButton;
    public TextMeshProUGUI PlacedLabel;
    public Color PlacedTextColor;
    public Color NotPlacedTextColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetupNewItemUI(object _itemObject)
    //{

    //}

    public void SetupApplianceItemUI(Appliance _applianceData)
    {
        MyItemID = _applianceData.applianceID;
        MyApplianceHash = _applianceData.ProfileHash;
        ItemImage.sprite = _applianceData.applianceImage;
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString() + " sec";
        ProduceQt.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.sellPrice.ToString();
        if(_applianceData.DynamicTileID == 0)
        {
            PlaceButton.gameObject.SetActive(true);
            ReplaceButton.gameObject.SetActive(false);
            SellButton.interactable = true;
            PlacedLabel.color = NotPlacedTextColor;
            PlacedLabel.text = "Not Placed!";
            myDynamicTileID = 0;
        }
        else
        {
            PlaceButton.gameObject.SetActive(false);
            ReplaceButton.gameObject.SetActive(true);
            SellButton.interactable = false;
            PlacedLabel.color = PlacedTextColor;
            PlacedLabel.text = "Placed!";
            myDynamicTileID = _applianceData.DynamicTileID;
        }
    }

    public void PlaceButtonEvent()
    {
        ShopUIController.Instance.isPlacing = true;
        ShopUIController.Instance.placingApplHash = MyApplianceHash;
        ShopUIController.Instance.PlaceMaskBehaviour(true);
    }

    public void ReplaceButtonEvent()
    {
        if(ProfileController.Instance.GetApplianceFromProfileByDynamicID(myDynamicTileID).ProfileHash == MyApplianceHash)
        {
            ProfileController.Instance.RemoveApplianceSlot(myDynamicTileID);
            BuildUIController.Instance.SetAppliancesSlotCount();
        }

    }


    public void SellButtonEvent()
    {

        ProfileController.Instance.SellApplianceByID(MyItemID);
        BuildUIController.Instance.SetupFoodItemSlotFromList(ProfileController.Instance.PlayerFoodItems, true);
        ShopUIController.Instance.GetAppliancesFromProfile(true);
        ShopUIController.Instance.GetPlayerCoinsFromProfile();
    }

    public void SetupFoodItemItemUI(FoodItem _foodItemData)
    {
        ItemImage.sprite = _foodItemData.foodImage;
        ItemName.text = _foodItemData.foodName;
        ItemCost.text = _foodItemData.sellPrice.ToString();
    }

    public void SetupIngredientItemUI(FoodIngredients _ingData)
    {
        MyItemID = _ingData.IngredientID;
        ItemImage.sprite = _ingData.IngredientImage;
        ItemName.text = _ingData.IngredientName;
        StoredAmount.text = _ingData.IngredientStoredAmount.ToString();
    }

    public void RefreshIngredientAmount(FoodIngredients _ingData)
    {
        int amount = ItemDatabase.Instance.GetFoodIngredientByID(_ingData.IngredientID).IngredientStoredAmount;
        StoredAmount.text = (amount + 1).ToString();
    }

}
