using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController Instance;

    private bool isBuildMode, isPlayMode;

    [Header("Dynamic Tiles")]
    public List<DynamicTile> DynamicTiles;
    public Material PlacingMaterial;
    public GameObject activePlacingApplliance;

    [Header("Orders")]
    public int maxOrdersNum;
    public int itemRepeatRate;
    public int orderWaitTime;
    public float orderMoveTimeToActive;
    public float orderMoveTimeInactive;
    public float orderWaitToOrderTime;
    public List<Order> Orders;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EnableBuildMode();

        ProfileController.Instance.LoadProfileFromFile();
        ShopUIController.Instance.GetAppliancesFromProfile(false);
        BuildUIController.Instance.SetupApplianceSlots();
        BuildUIController.Instance.SetupFoodItemSlotFromList(ProfileController.Instance.playerProfile.PlayerFoodItems, false);
        BuildUIController.Instance.SetFoodItemCount(ItemUIRow.itemType.Food);
        BuildUIController.Instance.SetFoodItemCount(ItemUIRow.itemType.Drink);
        CheckPlayerStartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Build/Play Mode handling
    public void EnableBuildMode()
    {
        isBuildMode = true;
        isPlayMode = false;
    }

    public void EnablePlayMode()
    {
        isPlayMode = true;
        isBuildMode = false;
        SetupOrders();
    }

    #endregion

    public void CheckPlayerStartGame()
    {
        if(ProfileController.Instance.CanPlayerStartGame())
        {
            ShopUIController.Instance.PlayButton.interactable = true;
        }
        else
        {
            ShopUIController.Instance.PlayButton.interactable = false;
        }
    }

    #region Dynamic Tile handling section

    IEnumerator SetApplianceToDynamicTile()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < DynamicTiles.Count; i++)
        {
            DynamicTiles[i].GetComponent<DynamicTile>().SetApplianceData(DynamicTiles[i]);
        }
    }

    public DynamicTile GetDynamicTIleByID(int _id)
    {
        for (int i = 0; i < DynamicTiles.Count; i++)
        {
            if(DynamicTiles[i].ID == _id)
            {
                return DynamicTiles[i];
            }
        }
        return null;
    }

    public void ClearActivePlacingAppliance()
    {
        if(activePlacingApplliance != null)
        {
            activePlacingApplliance = null;
        }

    }

    public void SetActivePlacingAppliance(GameObject _model)
    {
        if(activePlacingApplliance == null)
        {
            activePlacingApplliance = _model;
        }
    }

    #endregion

    #region Order Handling

    public void RefreshOrders()
    {
        OrderNPCController.Instance.ClearOrderNPCList();
        SetupOrders();
    }

    public void SetupOrders()
    {
        if(Orders.Count> 0)
        {
            Orders.Clear();
        }

        //How many fooditems will be order by the Customer
        int randomFoodItemCount;

        // Which FoodItem from the available fooditems
        int randomPickFoodIndex = 0;

        for (int i = 0; i < maxOrdersNum; i++)
        {
            Order newOrder = new Order();
            randomFoodItemCount = Random.Range(1, itemRepeatRate + 1);
            newOrder.OrderID = Orders.Count + 1;
            randomPickFoodIndex = Random.Range(0, ProfileController.Instance.playerProfile.PlayerFoodItems.Count);
            for (int a = 0; a < randomFoodItemCount; a++)
            {
                newOrder.OrderItems.Add(ProfileController.Instance.playerProfile.PlayerFoodItems[randomPickFoodIndex].foodID);
            }
            OrderNPCController.Instance.CreateNewOrderNPC(newOrder);
            Orders.Add(newOrder);
        }
        if(Orders.Count == maxOrdersNum)
        {
            StartCoroutine(OrderNPCController.Instance.Refresh(orderMoveTimeToActive, orderMoveTimeInactive));
        }
    }

    public void EnableNewOrderPanel(int _orderID)
    {
        if(!NewOrderUIController.Instance.NewOrderPanel.gameObject.activeSelf)
        {
            NewOrderUIController.Instance.NewOrderPanel.gameObject.SetActive(true);
            Order newOrderData = GetOrderByID(_orderID);
            NewOrderUIController.Instance.SetupNewOrderData(newOrderData);
        }
    }

    public Order GetOrderByID(int _id)
    {
        for (int i = 0; i < Orders.Count; i++)
        {
            if(Orders[i].OrderID == _id)
            {
                return Orders[i];
            }
        }
        return null;
    }

    #endregion

}
