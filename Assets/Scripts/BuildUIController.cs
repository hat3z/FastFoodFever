using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildUIController : MonoBehaviour
{
    [Header("BUILD PANEL")]
    public Animator BuildPanelAnimator;

    [Header("-Food Section")]
    public GameObject FoodUIRowPrefab;
    public Transform FoodParent;
    public List<ItemUIRow> FoodUIRows;

    [Header("-New Food--")]
    public GameObject NewFoodUIRowPrefab;
    public List<NewItemUIRow> NewFoodUIRows;

    [Header("-Drink Section")]
    public GameObject DrinkUIRowPrefab;
    public Transform DrinkParent;
    public List<ItemUIRow> DrinkUIRows;

    [Header("-New Drink--")]
    public GameObject NewDrinkUIRowPrefab;
    public List<NewItemUIRow> NewDrinkUIRows;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
