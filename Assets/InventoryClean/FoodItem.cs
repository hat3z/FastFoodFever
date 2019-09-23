using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodItem {

    public string foodName;
    public string foodID;
    public GameObject foodModel;
    public Sprite foodFillImage;
    public Sprite foodImage;
    public string description;

    public enum type { Food, Drink};
    public type Type;
    public enum tier { Low, Medium, High, Premium};
    public tier Tier;

    public int StoredAmount;
    public int sellPrice;
    public int costPrice;

    public List<IngredientRequest> Ingredients = new List<IngredientRequest>();
    public bool isLocked = true;
    public FoodItem MyClone()
    {
        FoodItem newItem = new FoodItem();

        newItem.foodID = foodID;
        newItem.foodName = foodName;
        newItem.foodModel = foodModel;
        newItem.foodFillImage = foodFillImage;
        newItem.foodImage = foodImage;
        newItem.description = description;
        newItem.Tier = Tier;
        newItem.StoredAmount = StoredAmount;
        newItem.sellPrice = sellPrice;
        newItem.costPrice = costPrice;
        newItem.Ingredients = Ingredients;
        newItem.isLocked = isLocked;
        return newItem;
    }

    /// <summary>
    /// Checks ONE IngredientRequest by the Ingredient stored amount.
    /// </summary>
    /// <param name="_ingredientRequest"></param>
    /// <returns></returns>
    public bool HasIngredient(IngredientRequest _ingredientRequest)
    {
        if(_ingredientRequest.amount >= ItemDatabase.Instance.GetFoodIngredientByID(_ingredientRequest.IngredientID).IngredientStoredAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Detecting all the IngredientRequests.
    /// </summary>
    /// <returns></returns>
    public bool CanCreateFoodItem()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            if(HasIngredient(Ingredients[i]))
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

}
[System.Serializable]
public class IngredientRequest
    {
    public string IngredientID;
    public int amount;

    }
