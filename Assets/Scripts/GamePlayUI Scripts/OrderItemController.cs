using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OrderItemController : MonoBehaviour
{

    public Image OrderItemImage;
    public TextMeshProUGUI OrderItemLabel;

    public Color EmptyItemColor;
    public Color AssignedItemColor;
    public bool isAssigned;

    public void SetupOrderItem(string _orderID)
    {
        Debug.Log("OrderID: " + _orderID);
        OrderItemImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(_orderID);
        OrderItemLabel.text = ItemDatabase.Instance.GetFoodItemByID(_orderID).foodName;
        isAssigned = false;
    }

}
