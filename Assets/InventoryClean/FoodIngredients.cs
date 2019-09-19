using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodIngredients
{
    public string IngredientName;
    public string IngredientID;
    public int IngredientStoredAmount;
    public int CostPrice;

    public FoodIngredients MyClone()
    {
        FoodIngredients newItem = new FoodIngredients();

        newItem.IngredientID = IngredientName;
        newItem.IngredientID = IngredientID;
        newItem.IngredientStoredAmount = IngredientStoredAmount;
        newItem.CostPrice = CostPrice;
        return newItem;
    }

}
