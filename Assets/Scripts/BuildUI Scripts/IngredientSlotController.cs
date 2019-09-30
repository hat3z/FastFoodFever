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
        IngImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(ItemDatabase.Instance.GetFoodIngredientByID(foodIngredients.IngredientID).IngredientImagePath);
        IngName.text = ItemDatabase.Instance.GetFoodIngredientByID(foodIngredients.IngredientID).IngredientName;
        IngAmount.text = foodIngredients.amount.ToString();

    }
}
