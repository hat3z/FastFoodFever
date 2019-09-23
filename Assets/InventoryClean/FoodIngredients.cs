using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodIngredients
{
    public string IngredientName;
    public string IngredientID;
    public Sprite IngredientImage;
    public int IngredientStoredAmount;
    public int CostPrice;
    public int TravelTime;
    public FoodIngredients MyClone()
    {
        FoodIngredients newItem = new FoodIngredients();

        newItem.IngredientName = IngredientName;
        newItem.IngredientID = IngredientID;
        newItem.IngredientStoredAmount = IngredientStoredAmount;
        newItem.IngredientImage = IngredientImage;
        newItem.CostPrice = CostPrice;
        newItem.TravelTime = TravelTime;
        return newItem;
    }

}
