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
    }

    #endregion

    public void LoadProfileToBuilderUI()
    {
        //FILE LOAD-->



    }

}
