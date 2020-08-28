using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FFM_ApplianceSlotUI : MonoBehaviour
{
    public enum applianceType { BurgerPad, CookerPad, DrinkMachine };
    public enum slotType { Player, Shop};
    [Header("Type")]
    public applianceType ApplianceType;
    public slotType SlotType;

    // privates
    private string myApplianceID;
    [Header("UI Objects")]
    public TextMeshProUGUI HeaderLabel;
    public TextMeshProUGUI ApplianceNameLabel;
    public TextMeshProUGUI ProduceTimeLabel;
    public TextMeshProUGUI ProduceQuantityLabel;
    public TextMeshProUGUI TierLabel;
    public TextMeshProUGUI PriceValueLabel;
    public RawImage ApplianceIcon;
    public RawImage ApplianceProduceIcon;
    public Button EventButton;

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

    public void SetupApplianceSlotUI(Appliance _applianceData)
    {
        ApplianceNameLabel.text = _applianceData.applianceName;
        ProduceTimeLabel.text = _applianceData.ProduceTime.ToString();
        ProduceQuantityLabel.text = _applianceData.ProduceQuantity.ToString();
        TierLabel.text = _applianceData.Tier.ToString();

        myApplianceID = _applianceData.applianceID;
        if(_applianceData.applianceImagePath != string.Empty)
        {
            ApplianceIcon.texture = ProfileController.Instance.GetSpriteFromResourcesByName(_applianceData.applianceID);
        }
        else
        {
            Debug.Log("Not image set for: " + _applianceData.applianceID);
            ApplianceIcon.texture = null;
        }

        ApplianceProduceIcon.texture = ProfileController.Instance.GetSpriteFromResourcesByName(_applianceData.produceID);

        if(SlotType == slotType.Shop)
        {
            PriceValueLabel.text = _applianceData.costPrice.ToString();
            SetShopApplianceType(_applianceData.ApplianceType);
        }
        if(SlotType == slotType.Player)
        {
            PriceValueLabel.text = _applianceData.sellPrice.ToString();
        }
        SubscribeToEventButton();

    }

    void SetShopApplianceType(Appliance.type _type)
    {
        switch (_type)
        {
            case Appliance.type.BurgerPad:
                ApplianceType = applianceType.BurgerPad;
                break;
            case Appliance.type.CookerPad:
                ApplianceType = applianceType.CookerPad;
                break;
            case Appliance.type.DrinkMachine:
                ApplianceType = applianceType.DrinkMachine;
                break;
            default:
                break;
        }
    }

    void SubscribeToEventButton()
    {
        switch (SlotType)
        {
            case slotType.Player:
                break;
            case slotType.Shop:
                EventButton.onClick.AddListener(delegate {
                    ProfileController.Instance.AddApplianceToProfile(ItemDatabase.Instance.GetApplianceByID(myApplianceID),
                    ApplianceType);});

                break;
            default:
                break;
        }
    }

    public void DetectApplianceSlot()
    {
        if (ProfileController.Instance.isApplianceSlotEmpty(ApplianceType))
        {
            FFM_PlayerUIController.Instance.ApplianceSlotControl(ApplianceType, false);
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
            FFM_PlayerUIController.Instance.ApplianceSlotControl(ApplianceType, true);
            SetupUI();
        }
    }



    void SetupUI()
    {
        switch (ApplianceType)
        {
            case applianceType.BurgerPad:
                HeaderLabel.text = "BurgerPad";
                SetupApplianceSlotUI(ProfileController.Instance.playerProfile.BurgerPadSlot);
                break;
            case applianceType.CookerPad:
                HeaderLabel.text = "CookerPad";
                SetupApplianceSlotUI(ProfileController.Instance.playerProfile.CookerPadSlot);
                break;
            case applianceType.DrinkMachine:
                HeaderLabel.text = "DrinkMachine";
                SetupApplianceSlotUI(ProfileController.Instance.playerProfile.DrinkMachineSlot);
                break;
            default:
                break;
        }
    }
}
