using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIRow : MonoBehaviour
{
    public enum itemType { Appliance, Food, Drink, Ingredient };
    public itemType ItemType;

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQt;
    public TextMeshProUGUI ItemCost;
    public TextMeshProUGUI StoredAmount;

    public Sprite PlacedSprite;
    public Sprite UnPlaceSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupApplianceItemUI(Appliance _applianceData)
    {
        ItemImage.sprite = _applianceData.applianceImage;
        ItemName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString() + " sec";
        ProduceQt.text = _applianceData.ProduceQuantity.ToString();
        ItemCost.text = _applianceData.costPrice.ToString();
    }

    public void SetupFoodItemItemUI(FoodItem _foodItemData)
    {
        ItemImage.sprite = _foodItemData.foodImage;
        ItemName.text = _foodItemData.foodName;
        ItemCost.text = _foodItemData.sellPrice.ToString();
    }

    public void SetupIngredientItemUI(FoodIngredients _foodItemData)
    {
        ItemImage.sprite = _foodItemData.IngredientImage;
        ItemName.text = _foodItemData.IngredientName;
        StoredAmount.text = _foodItemData.IngredientStoredAmount.ToString();
    }

}
