﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileController : MonoBehaviour
{

    public static ProfileController Instance;

    public string ProfileFilePath;

    public bool useDebug;
    public int PlayerMoney;

    public List<Appliance> PlayerAppliances;

    public List<FoodItem> PlayerFoodItems;

    public List<FoodIngredients> PlayerFoodIngredients;

    private void Awake()
    {
        Instance = this;
        ProfileFilePath = Application.persistentDataPath + "/Player.bin";
    }

    // Start is called before the first frame update
    void Start()
    {
        if(useDebug)
        {
            PlayerMoney = 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ----- Player Money management -----

    public bool CanBuyItemByCost(int _itemPrice)
    {
        if(_itemPrice <= PlayerMoney)
        {
            PlayerMoney -= _itemPrice;
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    public void AddItemToProfile(object _itemObject)
    {
        if(_itemObject is Appliance)
        {
            Appliance _applianceItem = (Appliance)_itemObject;
            if(CanBuyItemByCost(_applianceItem.costPrice))
            {
                _applianceItem.ProfileHash = StringRandomizer.Instance.GetRandomString();
                PlayerAppliances.Add(_applianceItem);
                UnlockFoodByAppliance(_applianceItem);
            }
        }
        if (_itemObject is FoodIngredients)
        {
            FoodIngredients _foodIngredientItem = (FoodIngredients)_itemObject;
            if (CanBuyItemByCost(_foodIngredientItem.CostPrice))
            {
                if(IsFoodIngredientExists(_foodIngredientItem.IngredientID))
                {
                    GetFoodIngredientFromProfile(_foodIngredientItem.IngredientID).IngredientStoredAmount += 1;
                }
                else
                {
                    _foodIngredientItem.IngredientStoredAmount = 1;
                    PlayerFoodIngredients.Add(_foodIngredientItem);
                }

            }
        }
    }

    #region ----- INGREDIENTS -----
    bool IsFoodIngredientExists(string _ingID)
    {
        for (int i = 0; i < PlayerFoodIngredients.Count; i++)
        {
            if(PlayerFoodIngredients[i].IngredientID == _ingID)
            {
                Debug.Log("has exists " + _ingID);
                return true;
            }
        }
        Debug.Log("not exists " + _ingID);
        return false;
    }

    FoodIngredients GetFoodIngredientFromProfile(string _requestID)
    {
        for (int i = 0; i < PlayerFoodIngredients.Count; i++)
        {
            if(PlayerFoodIngredients[i].IngredientID == _requestID)
            {
                Debug.Log("Requested Ingredient " + _requestID);
                return PlayerFoodIngredients[i];
            }
        }
        Debug.Log("Requested Ingredient is null");
        return null;
    }

    #endregion

    #region  ----- FOOD -----
    void UnlockFoodByAppliance(Appliance _applianceData)
    {
        FoodItem newFood = ItemDatabase.Instance.GetFoodItemByID(_applianceData.produceID);
        newFood.isLocked = false;
        if(!isFoodItemExists(_applianceData.produceID))
        {
            PlayerFoodItems.Add(newFood);
            BuildUIController.Instance.SetupFoodItemSlots(_applianceData, true);
        }

    }

    bool isFoodItemExists(string _foodID)
    {
        for (int i = 0; i < PlayerFoodItems.Count; i++)
        {
            if(PlayerFoodItems[i].foodID == _foodID)
            {
                return true;
            }
        }
        return false;
    }

    FoodItem GetFoodItemFromProfileByID(string _foodID)
    {
        for (int i = 0; i < PlayerFoodItems.Count; i++)
        {
            if(PlayerFoodItems[i].foodID == _foodID)
            {
                return PlayerFoodItems[i];
            }
        }
        return null;
    }

    public List<FoodItem> GetFoodListFromProfileByType(FoodItem.type foodType)
    {
        List<FoodItem> result = new List<FoodItem>();
        for (int i = 0; i < PlayerFoodItems.Count; i++)
        {
            if(foodType == PlayerFoodItems[i].Type)
            {
                result.Add(PlayerFoodItems[i]);
            }
        }
        return result;
    }

    #endregion

    #region ----- APPLIANCE -----

    public Appliance GetApplianceFromProfileByID(string _applID)
    {
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if(PlayerAppliances[i].applianceID == _applID)
            {
                return PlayerAppliances[i];
            }
            
        }
        return null;
    }

    public Appliance GetApplianceFromProfileByDynamicID(int _dynamicID)
    {
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if(PlayerAppliances[i].DynamicTileID == _dynamicID)
            {
                return PlayerAppliances[i];
            }
        }
        return null;
    }

    public Appliance GetApplianceFromProfileByDynamicID(int _dynamicID, string _aplID)
    {
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if(PlayerAppliances[i].applianceID == _aplID)
            {
                Debug.Log(PlayerAppliances[i].applianceID);
                if (PlayerAppliances[i].DynamicTileID == _dynamicID)
                {
                    Debug.Log(PlayerAppliances[i].applianceID);
                    return PlayerAppliances[i];
                }
            }

        }
        return null;
    }

    public Appliance GetApplianceFromProfileByHash(string _hash)
    {
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if (PlayerAppliances[i].ProfileHash == _hash)
            {
                return PlayerAppliances[i];
            }

        }
        return null;
    }

    bool HasApplianceWithDynamicID(string _aplID, int _dynamicID)
    {
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if (PlayerAppliances[i].applianceID == _aplID)
            {
                if (PlayerAppliances[i].DynamicTileID == _dynamicID)
                {
                    Debug.Log(PlayerAppliances[i].applianceID);
                    return true;
                }
                else
                {
                    Debug.Log("false");
                    return false;
                }
            }
            else
            {
                Debug.Log("false");
                return false;
            }
        }
        Debug.Log("false");
        return false;
    }

    public void SetApplianceToSlot(int _DynamicTIleID, string _applHash)
    {
        Appliance placingAppliance = GetApplianceFromProfileByHash(_applHash);
        Debug.Log(placingAppliance.applianceID + "dID:" + _DynamicTIleID);
        placingAppliance.DynamicTileID = _DynamicTIleID;
        GamePlayController.Instance.GetDynamicTIleByID(_DynamicTIleID).myAppliance = placingAppliance.applianceID;
        GamePlayController.Instance.GetDynamicTIleByID(_DynamicTIleID).myApplianceHash = placingAppliance.ProfileHash;
    }

    public void RemoveApplianceSlot(int id)
    {
        GamePlayController.Instance.GetDynamicTIleByID(id).myAppliance = string.Empty;
        GamePlayController.Instance.GetDynamicTIleByID(id).RemoveObjectModel();
        GetApplianceFromProfileByDynamicID(id).DynamicTileID = 0;
        BuildUIController.Instance.SetupApplianceSlots();
        ShopUIController.Instance.GetAppliancesFromProfile(false);
    }

    bool ApplianceHasDynamicTileByID( int _dynamicID)
    {
        if(GamePlayController.Instance.GetDynamicTIleByID(_dynamicID).ID == GetApplianceFromProfileByDynamicID(_dynamicID).DynamicTileID)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SellApplianceByID(string _itemID)
    {
        PlayerAppliances.Remove(GetApplianceFromProfileByID(_itemID));
        if (ApplianceCount(_itemID) < 1)
        {
            PlayerFoodItems.Remove(GetFoodItemFromProfileByID(ItemDatabase.Instance.GetApplianceByID(_itemID).produceID));
        }
        PlayerMoney += ItemDatabase.Instance.GetApplianceByID(_itemID).sellPrice;
    }

    int ApplianceCount(string _aplID)
    {
        int result = 0;
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if(PlayerAppliances[i].applianceID == _aplID)
            {
                result +=1;
                return result;
            }
        }
        return result;
    }

    public List<Appliance> GetPlacedAppliancesList()
    {
        List<Appliance> result = new List<Appliance>();
        for (int i = 0; i < PlayerAppliances.Count; i++)
        {
            if(PlayerAppliances[i].DynamicTileID != 0)
            {
                result.Add(PlayerAppliances[i]);

            }
        }
        return result;
    }

    #endregion

    public void LoadProfileToBuilderUI()
    {
        //FILE LOAD-->



    }

}
