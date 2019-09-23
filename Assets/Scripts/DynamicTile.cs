using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{

    public int ID;
    public string myAppliance;
    // Start is called before the first frame update
    void Start()
    {
        SetupNamesByType("Empty");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupNamesByType(string _appLName)
    {
        gameObject.name = "DynamicTile_" + _appLName;
    }

}
