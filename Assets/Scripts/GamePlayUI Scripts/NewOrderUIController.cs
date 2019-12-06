using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewOrderUIController : MonoBehaviour
{
    public static NewOrderUIController Instance;

    public GameObject NewOrderPanel;

    public TextMeshProUGUI OrderIDText;
    public RectTransform OrderItemsParent;

    public Image OrderTimerImg;

    private void Awake()
    {
        Instance = this;
        NewOrderPanel.gameObject.SetActive(false); 
    }

    public void SetupNewOrderData(Order _orderData)
    {
        for (int i = 0; i < OrderItemsParent.transform.childCount; i++)
        {
            Destroy(OrderItemsParent.transform.GetChild(i).gameObject);
        }
        OrderIDText.text = _orderData.OrderID.ToString();
        for (int i = 0; i < _orderData.OrderItems.Count; i++)
        {
            GameObject newOrderItem = Instantiate(new GameObject(), OrderItemsParent);
            newOrderItem.transform.localScale = new Vector3(1, 1, 1);
            newOrderItem.AddComponent<Image>().sprite = ItemDatabase.Instance.GetSpriteFromPath(_orderData.OrderItems[i]);

        }
    }

    public void PickUpOrder()
    {
        OrderNPCController.Instance.SetActiveOrderToWait();
        NewOrderPanel.gameObject.SetActive(false);
        OrderTimerImg.fillAmount = 1.0f;
        if (GameUIController.Instance.DragabblePanels[0].activeSelf)
        {
            OrdersPanelController.Instance.RefreshWaitingOrders();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NewOrderPanel.gameObject.activeSelf)
        {
            OrderTimerImg.fillAmount -= 1.0f / GamePlayController.Instance.orderPickupTime * Time.deltaTime;
        }

    }
}
