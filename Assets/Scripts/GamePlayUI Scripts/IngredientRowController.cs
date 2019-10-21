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
    float deliverTime;
    [Header("Buy settings")]
    public Button BuyButton;
    public TextMeshProUGUI BuyButtonLabel;
    public Button BuyAmountButton;
    public TextMeshProUGUI BuyAmountLabel;
    public int buyAmount;
    public int buyPrice;

    public GameObject UIContainer;
    public GameObject TravelContainer;
    public Image DeliverFillImage;
    bool startDeliver;
    float tempDeliverTime;
    private void Start()
    {
        BuyAmountButton.onClick.AddListener(() => AmountSelectButton.Instance.OpenAmountSelectorEvent(this));
        UIContainer.gameObject.SetActive(true);
        TravelContainer.gameObject.SetActive(false);
        startDeliver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startDeliver)
        {
            UIContainer.gameObject.SetActive(false);
            TravelContainer.gameObject.SetActive(true);
            tempDeliverTime -= Time.deltaTime;
            DeliverFillImage.fillAmount -= 1.0f / deliverTime * Time.deltaTime;
        }
        if(tempDeliverTime <=0)
        {
            startDeliver = false;
            UIContainer.gameObject.SetActive(true);
            TravelContainer.gameObject.SetActive(false);
            DeliverFillImage.fillAmount = 1.0f;
        }
    }

    public void SetupIngredientData(string _ingredientID)
    {
        FoodIngredients ingredientData = ProfileController.Instance.GetFoodIngredientFromProfile(_ingredientID);
        ingredientID = _ingredientID;
        IngNameLabel.text = ingredientData.IngredientName;
        IngStoredAmount.text = ingredientData.IngredientStoredAmount.ToString();
        IngImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(ingredientData.IngredientImagePath);
        buyAmount = 5;
        BuyAmountLabel.text = "x" + buyAmount.ToString();
        BuyButtonLabel.text = (ingredientData.CostPrice * buyAmount).ToString();
        deliverTime = ingredientData.TravelTime;
        
    }


    public void BuyButtonEvent()
    {
        StartCoroutine(RemoveAmountOfIngredient());
        tempDeliverTime = deliverTime;
        startDeliver = true;

    }

    IEnumerator RemoveAmountOfIngredient()
    {
        yield return new WaitForSeconds(ProfileController.Instance.GetFoodIngredientFromProfile(ingredientID).TravelTime);
        ProfileController.Instance.GetFoodIngredientFromProfile(ingredientID).IngredientStoredAmount += buyAmount;
        ProfileController.Instance.RemoveFromPlayerMoney(buyPrice);
        SetupIngredientData(ingredientID);
    }

}
//705889896