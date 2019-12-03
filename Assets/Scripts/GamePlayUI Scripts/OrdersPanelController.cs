using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OrdersPanelController : MonoBehaviour
{
    public static OrdersPanelController Instance;
    public GameplayUIButton MyGameplayButton;
    public GameObject OrderRowPrefab;
    public GameObject OrderItemPrefab;
    [Header("Tab Switcher")]
    public Color ActiveTabButtonColor;
    public Color InactiveTabButtonColor;
    public GameObject ActiveTabContent;

    [Space(5)]
    public GameObject OrdersContent;
    public Transform OrderContentWrapper;
    public GameObject ComplOrdersContent;
    public Transform ComplOrdersWrapper;

    [Header("Orders")]
    public List<Order> CompletedOrders;
    public List<Order> WaitingOrders;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RefreshWaitingOrders()
    {
        DeleteWaitingOrdersUI();
        for (int i = 0; i < OrderNPCController.Instance.waitingNPCs.Count; i++)
        {
            Order neworder = GamePlayController.Instance.GetOrderByID(OrderNPCController.Instance.waitingNPCs[i].myOrderID);
            WaitingOrders.Add(neworder);
            neworder.isWaiting = true;
        }

        for (int i = 0; i < WaitingOrders.Count; i++)
        {
            GameObject newWaitingOrderUI = Instantiate(OrderRowPrefab, OrderContentWrapper.transform);
            newWaitingOrderUI.transform.localScale = new Vector3(1, 1, 1);
            newWaitingOrderUI.GetComponent<OrderSlotController>().CreateOrderSlot(WaitingOrders[i]);
        }
    }

    public void RefreshActiveOrderContent(Order newOrderData)
    {
        DeleteWaitingOrdersUI();
        WaitingOrders.Add(newOrderData);

        for (int i = 0; i < WaitingOrders.Count; i++)
        {
            GameObject newWaitingOrderUI = Instantiate(OrderRowPrefab, OrdersContent.transform);
            newWaitingOrderUI.transform.localScale = new Vector3(1, 1, 1);
            newWaitingOrderUI.GetComponent<OrderSlotController>().CreateOrderSlot(newOrderData);
        }
    }

    void DeleteWaitingOrdersUI()
    {
        for (int i = 0; i < OrderContentWrapper.transform.childCount; i++)
        {
            Destroy(OrderContentWrapper.transform.GetChild(i).gameObject);
        }
        WaitingOrders.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Button Handlings
    public void ClosePanel()
    {
        MyGameplayButton.SetBaseColorToButton();
        gameObject.SetActive(false);
    }

    public void SetActiveColorToButton(Image _image)
    {
        _image.color = ActiveTabButtonColor;
    }
    public void SetBaseColorToButton(Image _image)
    {
        _image.color = InactiveTabButtonColor;
    }
    #endregion

    #region Tab Switching handling
    public void SwitchTabContent(GameObject _content)
    {
        if(ActiveTabContent != _content)
        {
            ActiveTabContent.gameObject.SetActive(false);
            ActiveTabContent = _content;
            ActiveTabContent.gameObject.SetActive(true);
        }
    }
    #endregion

}

[System.Serializable]
public class Order
{
    public int OrderID;
    public List<string> OrderItems = new List<string>();
    public bool isCompleted = false;
    public bool isWaiting = false;
}
