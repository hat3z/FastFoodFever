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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
