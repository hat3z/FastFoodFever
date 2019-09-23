using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildUIController : MonoBehaviour
{
    public static BuildUIController Instance;

    [Header("BUILD PANEL")]
    public Animator BuildPanelAnimator;

    [Header("Appliance Slots")]
    public GameObject ApplianceSlotPrefab;
    public Transform ApplSlotContent;
    public List<ApplianceSlotController> ApplianceSlots;

    [Header("-Food Section")]
    public GameObject FoodUIRowPrefab;
    public Transform FoodParent;
    public List<ItemUIRow> FoodUIRows;

    [Header("-New Food--")]
    public GameObject NewFoodUIRowPrefab;
    public List<NewItemUIRow> NewFoodUIRows;

    [Header("-Drink Section")]
    public GameObject DrinkUIRowPrefab;
    public Transform DrinkParent;
    public List<ItemUIRow> DrinkUIRows;

    [Header("-New Drink--")]
    public GameObject NewDrinkUIRowPrefab;
    public List<NewItemUIRow> NewDrinkUIRows;

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
    #region Appliances Slot handling
    void ClearAppliancesSlot()
    {
        for (int i = 0; i < ApplianceSlots.Count; i++)
        {
            Destroy(ApplianceSlots[i].gameObject);
        }
        ApplianceSlots.Clear();
    }

    public void SetupApplianceSlots()
    {
        ClearAppliancesSlot();
        for (int i = 0; i < GamePlayController.Instance.DynamicTiles.Count; i++)
        {
            GameObject newSlot = Instantiate(ApplianceSlotPrefab);
            newSlot.transform.SetParent(ApplSlotContent);
            newSlot.transform.SetAsFirstSibling();
            newSlot.transform.localScale = new Vector3(1, 1, 1);
            ApplianceSlots.Add(newSlot.GetComponent<ApplianceSlotController>());
            newSlot.GetComponent<ApplianceSlotController>().SetupSlotPrefab(GamePlayController.Instance.DynamicTiles[i]);
        }
    }
    #endregion
}
