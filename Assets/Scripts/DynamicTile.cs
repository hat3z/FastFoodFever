using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{

    public int ID;
    public string myAppliance;

    public Transform ObjectPivot;
    GameObject modelObject;
    public int rotatingAngle;

    Material modelMaterial;

    // Start is called before the first frame update
    void Start()
    {
        SetupNamesByType("Empty");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceAppliancePrefab(GameObject _object, bool isPreload)
    {
        Quaternion newRotate = Quaternion.Euler(new Vector3(0, rotatingAngle, 0));
        GameObject newObject = Instantiate(_object,ObjectPivot.transform.position, newRotate);
        newObject.transform.SetParent(ObjectPivot,true);
        modelObject = ObjectPivot.transform.GetChild(0).gameObject;
        if(isPreload)
        {
            SetSameMaterialToGameObject(GamePlayController.Instance.PlacingMaterial, newObject);
        }
    }

    public void SetSameMaterialToGameObject(Material _mat, GameObject _model)
    {
        for (int i = 0; i < _model.transform.childCount; i++)
        {
            if(_model.transform.GetChild(i).GetComponent<MeshRenderer>())
            {
                Debug.Log(_model.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].name);
                _model.transform.GetChild(i).GetComponent<MeshRenderer>().material = _mat;
            }
        }
    }

    public void RemoveObjectModel()
    {
        Destroy(modelObject);
        modelObject = null;
    }

    public void SetupNamesByType(string _appLName)
    {
        gameObject.name = "DynamicTile_" + _appLName;
    }

}
