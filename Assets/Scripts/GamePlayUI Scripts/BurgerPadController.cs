using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BurgerPadController : MonoBehaviour
{

    public GameObject BurgerPadPanel;

    public List<GameObject> Slots;
    public string myApplianceID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanelToAppliance(string _applianceID)
    {
        Appliance newAppliance = ProfileController.Instance.GetApplianceFromProfileByHash(_applianceID);
        for (int i = 0; i < newAppliance.ProduceQuantity; i++)
        {
            Slots[i].gameObject.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }

}
