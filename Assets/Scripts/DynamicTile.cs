using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{

    public enum applianceType {CookerBoard, BurgerBoard, DrinkMachine, SweetsBoard, UserDefined }

    public applianceType ApplianceType;

    public int ID;
    public string myAppliance;
    // Start is called before the first frame update
    void Start()
    {
        SetupNamesByType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupNamesByType()
    {
        gameObject.name = "DynamicTile_" + ApplianceType;
    }

}
