using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AmountSelectButton : MonoBehaviour
{
    public static AmountSelectButton Instance;
    public GameObject ButtonPanel;

    private IngredientRowController selectedController;
    public Vector2 offset;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ButtonPanel.gameObject.SetActive(false);
        selectedController = null;
    }

    public void OpenAmountSelectorEvent(IngredientRowController _controller)
    {
        if(selectedController == null)
        {
            ButtonPanel.gameObject.SetActive(true);

            ButtonPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                _controller.GetComponent<RectTransform>().anchoredPosition.x + offset.x,
                _controller.GetComponent<RectTransform>().anchoredPosition.y + offset.y);

            selectedController = _controller;
            selectedController.BuyButton.interactable = false;
        }
    }

    public void SelectAmount(int amount)
    {
        selectedController.BuyAmountLabel.text = "x" + amount.ToString();
        selectedController.buyAmount = amount;
        selectedController.buyPrice = ItemDatabase.Instance.GetFoodIngredientByID(selectedController.ingredientID).CostPrice * amount;
        selectedController.BuyButtonLabel.text = selectedController.buyPrice.ToString();
        ButtonPanel.gameObject.SetActive(false);
        if (ProfileController.Instance.CanBuyItem(selectedController.buyPrice))
        {
            selectedController.BuyButton.interactable = true;
        }
        else
        {
            selectedController.BuyButton.interactable = false;
        }
        selectedController = null;
    }

}
