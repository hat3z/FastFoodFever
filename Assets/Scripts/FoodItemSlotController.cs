using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodItemSlotController : MonoBehaviour
{
    public Image FoodItemImage;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI DescLabel;
    public TextMeshProUGUI SellPriceLabel;
    public Transform IngredientParent;
    public GameObject IngredientPrefab;
    public List<IngredientSlotController> Ingredients;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClearIngredientsList()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Destroy(Ingredients[i].gameObject);
        }
        Ingredients.Clear();
    }

    public void SetupItemData(FoodItem foodItemData)
    {

        FoodItemImage.sprite = foodItemData.foodImage;
        NameLabel.text = foodItemData.foodName;
        DescLabel.text = foodItemData.description;
        SellPriceLabel.text = foodItemData.sellPrice.ToString();

        ClearIngredientsList();

        for (int i = 0; i < foodItemData.Ingredients.Count; i++)
        {
            GameObject ingSlot = Instantiate(IngredientPrefab);
            ingSlot.transform.SetParent(IngredientParent);
            ingSlot.transform.SetAsLastSibling();
            ingSlot.transform.localScale = new Vector3(1, 1, 1);
            ingSlot.GetComponent<IngredientSlotController>().SetupIngredientSlot(foodItemData.Ingredients[i]);
            Ingredients.Add(ingSlot.GetComponent<IngredientSlotController>());
        }
    }

}
