using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Create new FoodDatabase")]
public class ItemDatabase : ScriptableObject {

    private static ItemDatabase _instance;
    public static ItemDatabase Instance {
        get {
            if (_instance == null) {
                _instance = (ItemDatabase)Resources.Load("FoodDatabase");
            }

            return _instance;
        }
    }

    [SerializeField]
    public List<FoodItem> FoodDatabase = new List<FoodItem>();
    public List<FoodIngredients> FoodIngredients = new List<FoodIngredients>();
    public List<Appliance> Appliances = new List<Appliance>();

    #region FoodItem item handlings

    public FoodItem GetFoodItemByID(string _itemIDName)
    {
        for (int i = 0; i < FoodDatabase.Count; i++)
        {
            if (FoodDatabase[i].foodID.ToLower() == _itemIDName.ToLower())
            {
                return FoodDatabase[i].MyClone();
            }
        }

        Debug.LogError("No object with this name." + _itemIDName);
        return null;
    }

    public bool IsValidFoodItemID(string _itemIDname)
    {
        for (int i = 0; i < FoodDatabase.Count; i++)
        {
            if (FoodDatabase[i].foodID == _itemIDname)
            {
                //Debug.Log("True");
                return true;
            }
        }
        //Debug.Log("False");
        return false;
    }

    // GAMEPLAY////////////////////////////////////

    public void CreateFoodItem(string _foodItemID)
    {
        if(GetFoodItemByID(_foodItemID).CanCreateFoodItem())
        {
            GetFoodItemByID(_foodItemID).StoredAmount += 1;
        }
    }

    // GAMEPLAY////////////////////////////////////

    /// <summary>
    /// Setups a new default item.
    /// </summary>
    /// <returns></returns>
    public FoodItem SetupNewFoodItem()
    {
        FoodItem _newItem = new FoodItem();
        _newItem.foodID = "null";
        _newItem.foodName = "Please rename me I am just a new item!";
        FoodDatabase.Add(_newItem);
        return _newItem;
    }

    public bool CheckNewItemID()
    {
        for (int i = 0; i < FoodDatabase.Count; i++)
        {
            if (FoodDatabase[i].foodID == "null")
            {
                return false;
            }
        }

        return true;
    }

    public void CreateNewDefaultItem()
    {
        if (CheckNewItemID())
        {
            SetupNewFoodItem();
            Debug.Log("Item was created.");
        }
        else if (!CheckNewItemID())
        {
            Debug.Log("Already has a default item, please refresh data.");
        }
    }
    #endregion


    #region FoodIngredients item handlings

    public FoodIngredients GetFoodIngredientByID(string _itemIDName)
    {
        for (int i = 0; i < FoodIngredients.Count; i++)
        {
            if (FoodIngredients[i].IngredientID.ToLower() == _itemIDName.ToLower())
            {
                return FoodIngredients[i].MyClone();
            }
        }

        Debug.LogError("No object with this name." + _itemIDName);
        return null;
    }

    public bool IsValidFoodIngredientID(string _itemIDname)
    {
        for (int i = 0; i < FoodIngredients.Count; i++)
        {
            if (FoodIngredients[i].IngredientID == _itemIDname)
            {
                //Debug.Log("True");
                return true;
            }
        }
        //Debug.Log("False");
        return false;
    }


    /// <summary>
    /// Setups a new default item.
    /// </summary>
    /// <returns></returns>
    public FoodIngredients SetupNewFoodIngredientItem()
    {
        FoodIngredients _newItem = new FoodIngredients();
        _newItem.IngredientID = "null";
        _newItem.IngredientName = "Please rename me I am just a new item!";
        FoodIngredients.Add(_newItem);
        return _newItem;
    }

    public bool CheckNewIngredientID()
    {
        for (int i = 0; i < FoodIngredients.Count; i++)
        {
            if (FoodIngredients[i].IngredientID == "null")
            {
                return false;
            }
        }

        return true;
    }

    public void CreateNewFoodIngredient()
    {
        if (CheckNewIngredientID())
        {
            SetupNewFoodIngredientItem();
            Debug.Log("Item was created.");
        }
        else if (!CheckNewIngredientID())
        {
            Debug.Log("Already has a default item, please refresh data.");
        }
    }
    #endregion

    #region Appliance item handlings

    public Appliance GetApplianceByID(string _itemIDName)
    {
        for (int i = 0; i < Appliances.Count; i++)
        {
            if (Appliances[i].applianceID.ToLower() == _itemIDName.ToLower())
            {
                return Appliances[i].MyClone();
            }
        }

        Debug.LogError("No object with this name." + _itemIDName);
        return null;
    }

    public bool IsValidApplianceID(string _itemIDname)
    {
        for (int i = 0; i < Appliances.Count; i++)
        {
            if (Appliances[i].applianceID == _itemIDname)
            {
                //Debug.Log("True");
                return true;
            }
        }
        //Debug.Log("False");
        return false;
    }

    /// <summary>
    /// Setups a new default item.
    /// </summary>
    /// <returns></returns>
    public Appliance SetupNewApplianceItem()
    {
        Appliance _newItem = new Appliance();
        _newItem.applianceID = "null";
        _newItem.applianceName = "Please rename me I am just a new item!";
        Appliances.Add(_newItem);
        return _newItem;
    }

    public bool CheckNewApplianceID()
    {
        for (int i = 0; i < Appliances.Count; i++)
        {
            if (Appliances[i].applianceID == "null")
            {
                return false;
            }
        }

        return true;
    }

    public void CreateNewAppliance()
    {
        if (CheckNewApplianceID())
        {
            SetupNewApplianceItem();
            Debug.Log("Item was created.");
        }
        else if (!CheckNewApplianceID())
        {
            Debug.Log("Already has a default item, please refresh data.");
        }
    }
    #endregion

}
