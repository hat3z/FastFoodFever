using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderSlotController : MonoBehaviour
{

    public enum orderType {Assignable,NotCompleted, Completed };
    public orderType OrderType;

    public TextMeshProUGUI OrderIDLabel;
    public Button ReadyOrderButton;
    public TextMeshProUGUI OrderReadyLabel;
    public Image CountdownTimerImg;
    public RectTransform OrdersWrapper;
    public List<OrderItemController> OrderItems;
    public GameObject OrderItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimerImg.fillAmount -= 1.0f / GamePlayController.Instance.orderWaitTime * Time.deltaTime;

    }


    public void CreateOrderSlot(Order _orderData)
    {
        for (int i = 0; i < _orderData.OrderItems.Count; i++)
        {
            GameObject newOrderItem = Instantiate(OrderItemPrefab, OrdersWrapper);
            newOrderItem.transform.localScale = new Vector3(1, 1, 1);
            newOrderItem.GetComponent<OrderItemController>().SetupOrderItem(_orderData.OrderItems[i]);
            ReadyOrderButton.interactable = false;
            OrderIDLabel.text = "Order#" + _orderData.OrderID;
        }
    }

    //--->>
    //TODO: Create OrderSlot prefabs, setup by Order class.
    //<<---
}
