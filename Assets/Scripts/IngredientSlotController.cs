using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientSlotController : MonoBehaviour
{

    public Image IngImage;
    public TextMeshProUGUI IngName;
    public TextMeshProUGUI IngAmount;

    public void SetupIngredientSlot(IngredientRequest foodIngredients)
    {
        IngImage.sprite = ItemDatabase.Instance.GetFoodIngredientByID(foodIngredients.IngredientID).IngredientImage;
        IngName.text = ItemDatabase.Instance.GetFoodIngredientByID(foodIngredients.IngredientID).IngredientName;
        IngAmount.text = foodIngredients.amount.ToString();

    }
}
