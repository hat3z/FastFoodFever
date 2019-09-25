using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildUIController : MonoBehaviour
{
    public static BuildUIController Instance;

    [Header("Appliance Slots")]
    public GameObject ApplianceSlotPrefab;
    public Transform ApplSlotContent;
    public List<ApplianceSlotController> ApplianceSlots;
    public TextMeshProUGUI ApplCounterLabel;
    public TextMeshProUGUI ApplShowText;

    [Header("-Food Section")]
    public GameObject FoodUIRowPrefab;
    public Transform FoodParent;
    public List<FoodItemSlotController> FoodUIRows;
    public TextMeshProUGUI FoodCounterLabel;
    public TextMeshProUGUI FoodShowText;

    [Header("-Drink Section")]
    public Transform DrinkParent;
    public List<FoodItemSlotController> DrinkUIRows;
    public TextMeshProUGUI DrinkCounterLabel;
    public TextMeshProUGUI DrinkShowText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowItems(string itemType)
    {
        bool _state;
        switch (itemType)
        {
            case "appliance":
                _state = ApplSlotContent.gameObject.activeSelf;
                ApplSlotContent.gameObject.SetActive(!_state);
                if (_state)
                {
                    ApplShowText.text = "Show";
                }
                else
                {
                    ApplShowText.text = "Hide";
                }
                break;
            case "food":
                _state = FoodParent.gameObject.activeSelf;
                FoodParent.gameObject.SetActive(!_state);
                if (_state)
                {
                    FoodShowText.text = "Show";
                }
                else
                {
                    FoodShowText.text = "Hide";
                }
                break;
            case "drink":
                _state = DrinkParent.gameObject.activeSelf;
                DrinkParent.gameObject.SetActive(!_state);
                if (_state)
                {
                    DrinkShowText.text = "Show";
                }
                else
                {
                    DrinkShowText.text = "Hide";
                }
                break;
            default:
                break;
        }
    }

    #region Appliances Slot handling
    void ClearAppliancesSlot()
    {
        for (int i = 0; i < ApplianceSlots.Count; i++)
        {
            Destroy(ApplianceSlots[i].gameObject);
        }
        ApplianceSlots.Clear();
    }

    public void SetAppliancesSlotCount()
    {
        ApplCounterLabel.text = (ProfileController.Instance.GetPlacedAppliancesList().Count + "/" + ProfileController.Instance.PlayerAppliances.Count).ToString();
    }

    public void SetupApplianceSlots()
    {
        ClearAppliancesSlot();
        for (int i = 0; i < GamePlayController.Instance.DynamicTiles.Count; i++)
        {
            GameObject newSlot = Instantiate(ApplianceSlotPrefab);
            newSlot.transform.SetParent(ApplSlotContent);
            newSlot.transform.SetAsLastSibling();
            newSlot.transform.localScale = new Vector3(1, 1, 1);
            ApplianceSlots.Add(newSlot.GetComponent<ApplianceSlotController>());
            newSlot.GetComponent<ApplianceSlotController>().SetupSlotPrefab(GamePlayController.Instance.DynamicTiles[i]);
        }
    }
    #endregion

    #region FoodItems Slot Handling

    void ClearFoodSlotsList()
    {
        for (int i = 0; i < FoodUIRows.Count; i++)
        {
            Destroy(FoodUIRows[i].gameObject);
        }
        FoodUIRows.Clear();
    }

    void ClearDrinkSlots()
    {
        for (int i = 0; i < DrinkUIRows.Count; i++)
        {
            Destroy(DrinkUIRows[i].gameObject);
        }
        DrinkUIRows.Clear();
    }

    public void SetFoodItemCount(ItemUIRow.itemType itemType)
    {
        switch (itemType)
        {
            case ItemUIRow.itemType.Appliance:
                break;
            case ItemUIRow.itemType.Food:
                FoodCounterLabel.text = ProfileController.Instance.GetFoodListFromProfileByType(FoodItem.type.Food).Count.ToString();
                break;
            case ItemUIRow.itemType.Drink:
                DrinkCounterLabel.text = ProfileController.Instance.GetFoodListFromProfileByType(FoodItem.type.Drink).Count.ToString();
                break;
            case ItemUIRow.itemType.Ingredient:
                break;
            default:
                break;
        }
    }

    public void SetupFoodItemSlotFromList(List<FoodItem> _fooditemList, bool useActivating)
    {
        ClearFoodSlotsList();
        SetFoodItemCount(ItemUIRow.itemType.Food);

        ClearDrinkSlots();
        SetFoodItemCount(ItemUIRow.itemType.Drink);
        if (useActivating)
        {
            StartCoroutine(ShopUIController.Instance.RefreshPanelWithDelay(FoodParent.gameObject));
        }
        for (int i = 0; i < _fooditemList.Count; i++)
        {

            if (_fooditemList[i].Type == FoodItem.type.Food)
            {
                GameObject newFoodRow = Instantiate(FoodUIRowPrefab);
                newFoodRow.transform.SetParent(FoodParent);
                newFoodRow.transform.SetAsLastSibling();
                newFoodRow.transform.localScale = new Vector3(1, 1, 1);
                newFoodRow.GetComponent<FoodItemSlotController>().SetupItemData(ProfileController.Instance.PlayerFoodItems[i]);
                FoodUIRows.Add(newFoodRow.GetComponent<FoodItemSlotController>());
            }
            if(_fooditemList[i].Type == FoodItem.type.Drink)
            {
                GameObject newFoodRow = Instantiate(FoodUIRowPrefab);
                newFoodRow.transform.SetParent(DrinkParent);
                newFoodRow.transform.SetAsLastSibling();
                newFoodRow.transform.localScale = new Vector3(1, 1, 1);
                newFoodRow.GetComponent<FoodItemSlotController>().SetupItemData(ProfileController.Instance.PlayerFoodItems[i]);
                DrinkUIRows.Add(newFoodRow.GetComponent<FoodItemSlotController>());
            }
        }
    }

    public void SetupFoodItemSlots(Appliance applianceData, bool useActivating)
    {
        ClearFoodSlotsList();
        ClearDrinkSlots();
        FoodItem food = ItemDatabase.Instance.GetFoodItemByID(applianceData.produceID);
        if(food.Type == FoodItem.type.Food)
        {
            if (useActivating)
            {
                StartCoroutine(ShopUIController.Instance.RefreshPanelWithDelay(FoodParent.gameObject));
            }

            for (int i = 0; i < ProfileController.Instance.GetFoodListFromProfileByType(FoodItem.type.Food).Count; i++)
            {
                GameObject newFoodRow = Instantiate(FoodUIRowPrefab);
                newFoodRow.transform.SetParent(FoodParent);
                newFoodRow.transform.SetAsLastSibling();
                newFoodRow.transform.localScale = new Vector3(1, 1, 1);
                newFoodRow.GetComponent<FoodItemSlotController>().SetupItemData(ProfileController.Instance.PlayerFoodItems[i]);
                FoodUIRows.Add(newFoodRow.GetComponent<FoodItemSlotController>());
            }

            SetFoodItemCount(ItemUIRow.itemType.Food);
        }
        if(food.Type == FoodItem.type.Drink)
        {
            if (useActivating)
            {
                StartCoroutine(ShopUIController.Instance.RefreshPanelWithDelay(DrinkParent.gameObject));
            }

            for (int i = 0; i < ProfileController.Instance.GetFoodListFromProfileByType(FoodItem.type.Drink).Count; i++)
            {
                GameObject newFoodRow = Instantiate(FoodUIRowPrefab);
                newFoodRow.transform.SetParent(DrinkParent);
                newFoodRow.transform.SetAsLastSibling();
                newFoodRow.transform.localScale = new Vector3(1, 1, 1);
                newFoodRow.GetComponent<FoodItemSlotController>().SetupItemData(ProfileController.Instance.PlayerFoodItems[i]);
                DrinkUIRows.Add(newFoodRow.GetComponent<FoodItemSlotController>());
            }

            SetFoodItemCount(ItemUIRow.itemType.Drink);
        }

    }

    #endregion

}
