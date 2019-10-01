using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuItemController : MonoBehaviour
{

    public string foodItemID;

    public Image foodItemImage;
    public TextMeshProUGUI FoodItemName;
    public TextMeshProUGUI FoodItemPrice;

    public void SetupFoodItemData(string _foodID)
    {
        FoodItem food = ItemDatabase.Instance.GetFoodItemByID(_foodID);
        foodItemImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(food.foodImagePath);
        FoodItemName.text = food.foodName;
        FoodItemPrice.text = food.sellPrice.ToString();
    }
}
