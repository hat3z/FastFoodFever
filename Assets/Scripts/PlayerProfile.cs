using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile 
{
    public string RestaurantName;

    public string RestaurantImagePath;

    public int PlayerMoney;

    public List<Appliance> PlayerAppliances;

    public List<FoodItem> PlayerFoodItems;

    public List<FoodIngredients> PlayerFoodIngredients;

}
