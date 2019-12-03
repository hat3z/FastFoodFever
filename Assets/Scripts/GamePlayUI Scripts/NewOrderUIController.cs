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


    private void Awake()
    {
        Instance = this;
        NewOrderPanel.gameObject.SetActive(false);
    }

    public void SetupNewOrderData(Order _orderData)
    {
        OrderIDText.text = _orderData.OrderID.ToString();
        for (int i = 0; i < _orderData.OrderItems.Count; i++)
        {
            GameObject newOrderItem = Instantiate(new GameObject(), OrderItemsParent);
            newOrderItem.transform.localScale = new Vector3(1, 1, 1);
            newOrderItem.AddComponent<Image>().sprite = ItemDatabase.Instance.GetSpriteFromPath(_orderData.OrderItems[i]);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
