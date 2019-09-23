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

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQt;
    public TextMeshProUGUI ItemCost;
    public TextMeshProUGUI StoredAmount;

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
        ItemImage.sprite = _applianceData.applianceImage;
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString() + " sec";
        ProduceQt.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.sellPrice.ToString();
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
