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
    public Button BuyButton;
    public TextMeshProUGUI BuyButtonLabel;
    public Button BuyAmountButton;
    public TextMeshProUGUI BuyAmountLabel;
    public int buyAmount;
    public int buyPrice;

    private void Start()
    {
        BuyAmountButton.onClick.AddListener(() => AmountSelectButton.Instance.OpenAmountSelectorEvent(this));
    }

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
        BuyButtonLabel.text = ingredientData.CostPrice.ToString();
    }
    public void BuyButtonEvent()
    {
        ProfileController.Instance.GetFoodIngredientFromProfile(ingredientID).IngredientStoredAmount += buyAmount;
        ProfileController.Instance.RemoveFromPlayerMoney(buyPrice);
        IngredientsPanelController.Instance.DrawIngredients();
    }
}
//705889896