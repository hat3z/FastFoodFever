﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DynamicTile : MonoBehaviour
{

    public int ID;
    public string myAppliance;
    public string myApplianceHash;

    public Transform ObjectPivot;
    GameObject modelObject;
    GameObject placingObject;
    public int rotatingAngle;

    Material modelMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetApplianceData()
    {
        Appliance loaded = ProfileController.Instance.GetApplianceFromProfileByHash(myApplianceHash);
        Debug.Log(loaded.applianceID);
        if(loaded == null)
        {
            SetupNamesByType("Empty");
        }
        else
        {
            SetupNamesByType(myAppliance);
            myAppliance = loaded.applianceID;
            myApplianceHash = loaded.ProfileHash;
        }
    }
    
    public void PlaceAppliancePrefab(string _objectPath, bool isPreload)
    {
        RemoveObjectModel();
        Quaternion newRotate = Quaternion.Euler(new Vector3(0, rotatingAngle, 0));
        GameObject newObject = Instantiate(ItemDatabase.Instance.GetGameObjectFromPath(_objectPath),ObjectPivot.transform.position, newRotate);
        newObject.transform.SetParent(ObjectPivot,true);
        modelObject = newObject;
        if (isPreload)
        {
            SetSameMaterialToGameObject(GamePlayController.Instance.PlacingMaterial, newObject);
            placingObject = ObjectPivot.transform.GetChild(0).gameObject;
        }
    }

    public void SetSameMaterialToGameObject(Material _mat, GameObject _model)
    {
        for (int i = 0; i < _model.transform.childCount; i++)
        {
            if(_model.transform.GetChild(i).GetComponent<MeshRenderer>())
            {
                _model.transform.GetChild(i).GetComponent<MeshRenderer>().material = _mat;
            }
        }
    }

    public void RemoveObjectModel()
    {
        if(modelObject != null)
        {
            Destroy(modelObject.gameObject);
            modelObject = null;
            SetupNamesByType("Empty");
        }

    }

    public void RemovePlacingObject()
    {
        if(placingObject != null)
        {
            Destroy(placingObject.gameObject);
            placingObject = null;
        }
    }

    public void SetupNamesByType(string _appLName)
    {
        gameObject.name = "DynamicTile_" + _appLName;
    }

}
