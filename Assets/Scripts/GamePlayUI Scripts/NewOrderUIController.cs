using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewOrderUIController : MonoBehaviour
{
    public static NewOrderUIController Instance;

    public TextMeshProUGUI OrderIDText;
    public RectTransform OrderItemsParent;


    private void Awake()
    {
        Instance = this;
    }

    public void SetupNewOrderData(Order _orderData)
    {

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
