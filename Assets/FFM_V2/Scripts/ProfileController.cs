using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class ProfileController : MonoBehaviour
{

    public static ProfileController Instance;

    public string ProfileFilePath;

    string ProfileFileName = "Profile.save";

    public bool useDebug;
    public bool useSaving;    

    public PlayerProfile playerProfile;

    private void Awake()
    {
        Instance = this;
        ProfileFilePath = Application.persistentDataPath;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ----- Player Money management -----

    public bool CanBuyItemByCost(int _itemPrice)
    {

        if(_itemPrice <= playerProfile.PlayerMoney)
        {
            playerProfile.PlayerMoney -= _itemPrice;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanBuyItem(int _itemPrice)
    {
        if (_itemPrice <= playerProfile.PlayerMoney)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveFromPlayerMoney(int _amount)
    {
        playerProfile.PlayerMoney -= _amount;
        SavePlayerProfileToFile();
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
                //playerProfile.PlayerAppliances.Add(_applianceItem);
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
                    playerProfile.PlayerFoodIngredients.Add(_foodIngredientItem);
                }

            }
        }
    }



    #region ----- INGREDIENTS -----
    bool IsFoodIngredientExists(string _ingID)
    {
        for (int i = 0; i < playerProfile.PlayerFoodIngredients.Count; i++)
        {
            if(playerProfile.PlayerFoodIngredients[i].IngredientID == _ingID)
            {
                Debug.Log("has exists " + _ingID);
                return true;
            }
        }
        Debug.Log("not exists " + _ingID);
        return false;
    }

    public FoodIngredients GetFoodIngredientFromProfile(string _requestID)
    {
        for (int i = 0; i < playerProfile.PlayerFoodIngredients.Count; i++)
        {
            if(playerProfile.PlayerFoodIngredients[i].IngredientID == _requestID)
            {
                Debug.Log("Requested Ingredient " + _requestID);
                return playerProfile.PlayerFoodIngredients[i];
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
        Debug.Log(newFood.foodID);
        if(!isFoodItemExists(_applianceData.produceID))
        {
            playerProfile.PlayerFoodItems.Add(newFood);
            //BuildUIController.Instance.SetupFoodItemSlots(_applianceData, false);

        }
    }

    bool isFoodItemExists(string _foodID)
    {
        for (int i = 0; i < playerProfile.PlayerFoodItems.Count; i++)
        {
            if(playerProfile.PlayerFoodItems[i].foodID == _foodID)
            {
                return true;
            }
        }
        return false;
    }

    FoodItem GetFoodItemFromProfileByID(string _foodID)
    {
        for (int i = 0; i < playerProfile.PlayerFoodItems.Count; i++)
        {
            if(playerProfile.PlayerFoodItems[i].foodID == _foodID)
            {
                return playerProfile.PlayerFoodItems[i];
            }
        }
        return null;
    }

    public List<FoodItem> GetFoodListFromProfileByType(FoodItem.type foodType)
    {
        List<FoodItem> result = new List<FoodItem>();
        for (int i = 0; i < playerProfile.PlayerFoodItems.Count; i++)
        {
            if(foodType == playerProfile.PlayerFoodItems[i].Type)
            {
                result.Add(playerProfile.PlayerFoodItems[i]);
            }
        }
        return result;
    }

    #endregion

    #region ----- APPLIANCE -----

    public void SellApplianceByID(string _itemID)
    {
        playerProfile.PlayerMoney += ItemDatabase.Instance.GetApplianceByID(_itemID).sellPrice;
    }

    public bool isApplianceSlotEmpty(FFM_ApplianceSlotUI.applianceType _type)
    {
        switch (_type)
        {
            case FFM_ApplianceSlotUI.applianceType.BurgerPad:
                if(playerProfile.BurgerPadSlot == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FFM_ApplianceSlotUI.applianceType.CookerPad:
                if (playerProfile.CookerPadSlot == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case FFM_ApplianceSlotUI.applianceType.DrinkMachine:
                if (playerProfile.DrinkMachineSlot == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                break;
        }
        return false;
    }

    #endregion

    #region SAVE AND LOAD HANDLING

    public void SavePlayerProfileToFile()
    {
        File.Delete(ProfileFilePath + Path.DirectorySeparatorChar + ProfileFileName);
        PlayerProfile profile = playerProfile;
        BinaryFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(ProfileFilePath + Path.DirectorySeparatorChar + ProfileFileName, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, profile);
        stream.Close();
        Debug.Log("Profile has been saved!");
    }

    public void LoadProfileFromFile()
    {
        // CLEARING
        playerProfile.BurgerPadSlot = null;
        playerProfile.CookerPadSlot = null;
        playerProfile.DrinkMachineSlot = null;
        playerProfile.PlayerFoodIngredients.Clear();
        playerProfile.PlayerFoodItems.Clear();
        if (useDebug)
        {
            playerProfile.PlayerMoney = 500;
        }
        else
        {
            playerProfile.PlayerMoney = 0;
        }
        playerProfile.RestaurantName = string.Empty;
        playerProfile.RestaurantImagePath = string.Empty;

        if(File.Exists(ProfileFilePath + Path.DirectorySeparatorChar + ProfileFileName))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ProfileFilePath + Path.DirectorySeparatorChar + ProfileFileName, FileMode.Open, FileAccess.Read);
            PlayerProfile loadedProfile = (PlayerProfile)formatter.Deserialize(stream);
            playerProfile = loadedProfile;
            stream.Close();
        }

    }
    #endregion


}
