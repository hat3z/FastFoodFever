using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewApplianceUIRow : MonoBehaviour
{

    public Image ApplianceImage;
    public TextMeshProUGUI ApplianceName;
    public TextMeshProUGUI ProduceTime;
    public TextMeshProUGUI ProduceQuantity;
    public TextMeshProUGUI ApplianceCost;


    public void SetupAppliance(Appliance _applianceData)
    {
        ApplianceImage.sprite = _applianceData.applianceImage;
        ApplianceName.text = _applianceData.applianceName;
        ProduceTime.text = _applianceData.ProduceTime.ToString();
        ProduceQuantity.text = _applianceData.ProduceQuantity.ToString();
        ApplianceCost.text = _applianceData.costPrice.ToString();
    }
}
