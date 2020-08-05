using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FFM_ApplianceSlotUI : MonoBehaviour
{
    public enum applianceType { BurgerPad, CookerPad, DrinkMachine };
    [Header("Type")]
    public applianceType ApplianceType;

    [Header("UI Objects")]
    public TextMeshProUGUI HeaderLabel;
    public TextMeshProUGUI ApplianceNameLabel;
    public TextMeshProUGUI ProduceTimeLabel;
    public TextMeshProUGUI ProduceQuantityLabel;
    public TextMeshProUGUI TierLabel;
    public TextMeshProUGUI SellValueLabel;
    public Image ApplianceIcon;
    public Image ApplianceProduceIcon;
    

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectApplianceSlot()
    {
        if(ProfileController.Instance.isApplianceSlotEmpty(ApplianceType))
        {
            FFM_PlayerUIController.Instance.ApplianceSlotControl(ApplianceType, false);
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
            FFM_PlayerUIController.Instance.ApplianceSlotControl(ApplianceType, true);
        }
    }

}
