using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodIngredients
{
    public string IngredientName;
    public string IngredientID;
    public string IngredientImagePath;
    public int IngredientStoredAmount;
    public int CostPrice;
    public int TravelTime;
    public FoodIngredients MyClone()
    {
        FoodIngredients newItem = new FoodIngredients();

        newItem.IngredientName = IngredientName;
        newItem.IngredientID = IngredientID;
        newItem.IngredientStoredAmount = IngredientStoredAmount;
        newItem.IngredientImagePath = IngredientImagePath;
        newItem.CostPrice = CostPrice;
        newItem.TravelTime = TravelTime;
        return newItem;
    }

}
