using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile 
{
    public string RestaurantName;

    public string RestaurantImagePath;

    public int PlayerMoney;
    public Appliance BurgerPadSlot;
    public Appliance CookerPadSlot;
    public Appliance DrinkMachineSlot;

    public List<FoodItem> PlayerFoodItems;

    public List<FoodIngredients> PlayerFoodIngredients;

}
