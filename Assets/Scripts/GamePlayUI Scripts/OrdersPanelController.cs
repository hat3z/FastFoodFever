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
    public GameObject ComplOrdersContent;

    [Header("Orders")]
    public List<Order> CompletedOrders;
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
    public bool isActive = false;
}
