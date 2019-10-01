using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngredientRowController : MonoBehaviour
{
    public string ingredientID;
    public TextMeshProUGUI IngNameLabel;
    public TextMeshProUGUI IngStoredAmount;
    public Image IngImage;

    [Header("Buy settings")]
    public GameObject BuyButtonPanel;
    public Button BuyButton;
    public TextMeshProUGUI BuyButtonLabel;
    public TextMeshProUGUI BuyAmountLabel;
    int buyAmount;
    int buyPrice;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupIngredientData(string _ingredientID)
    {
        FoodIngredients ingredientData = ProfileController.Instance.GetFoodIngredientFromProfile(_ingredientID);
        ingredientID = _ingredientID;
        IngNameLabel.text = ingredientData.IngredientName;
        IngStoredAmount.text = ingredientData.IngredientStoredAmount.ToString();
        IngImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(ingredientData.IngredientImagePath);
        SelectAmount(1);
    }

    #region BuyAmount handling
    public void OpenAmountSelectorEvent()
    {
        BuyButtonPanel.gameObject.SetActive(true);
        BuyButton.interactable = false;
    }

    public void SelectAmount(int amount)
    {
        BuyAmountLabel.text = "x" + amount.ToString();
        buyAmount = amount;
        buyPrice = ItemDatabase.Instance.GetFoodIngredientByID(ingredientID).CostPrice * amount;
        BuyButtonLabel.text = buyPrice.ToString();
        BuyButtonPanel.gameObject.SetActive(false);
        if(ProfileController.Instance.CanBuyItem(buyPrice))
        {
            BuyButton.interactable = true;
        }
        else
        {
            BuyButton.interactable = false;
        }
    }

    public void BuyButtonEvent()
    {
        ProfileController.Instance.GetFoodIngredientFromProfile(ingredientID).IngredientStoredAmount += buyAmount;
        ProfileController.Instance.RemoveFromPlayerMoney(buyPrice);
        IngredientsPanelController.Instance.DrawIngredients();
    }

    #endregion
}
//705889896