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

    public List<OrderItemController> OrderItems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
