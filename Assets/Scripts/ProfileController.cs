using System.Collections;
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

    #region Player Money management

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

    public void AddItemToProfile(object _itemObject)
    {
        if(_itemObject is Appliance)
        {
            Appliance _applianceItem = (Appliance)_itemObject;
            if(CanBuyItemByCost(_applianceItem.costPrice))
            {
                PlayerAppliances.Add(_applianceItem);
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

    public void LoadProfileToBuilderUI()
    {
        //FILE LOAD-->



    }

}
