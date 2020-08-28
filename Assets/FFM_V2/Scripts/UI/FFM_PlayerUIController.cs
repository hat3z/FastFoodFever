using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FFM_PlayerUIController : MonoBehaviour
{
    public static FFM_PlayerUIController Instance;
    GameObject Player;
    PlayerLook playerLook;


    [Header("Canvases")]
    public Canvas PlayerCanvas;
    public Canvas RestaurantCanvas;

    [Header("Player Coins")]
    public TextMeshProUGUI playerCoinsValueText;

    [Header("Shop UI")]
    public GameObject ApplianceSlotShop;
    public RectTransform ContentWrapper;

    [Header("BurgerPad Slot")]
    public FFM_ApplianceSlotUI BurgerPadSlot;
    public GameObject BurgerPadSlotEmpty;

    [Header("CookerPad Slot")]
    public FFM_ApplianceSlotUI CookerPadSlot;
    public GameObject CookerPadSlotEmpty;

    [Header("DrinkMachine Slot")]
    public FFM_ApplianceSlotUI DrinkMachineSlot;
    public GameObject DrinkMachineSlotEmpty;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }
        playerLook = Player.GetComponent<PlayerLook>();
        playerLook.enabled = false;
        RestaurantCanvas.gameObject.SetActive(false);
        PlayerCanvas.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshAppliancesContent();

    }

    #region --- APPLIANCES --- 

    public void RefreshAppliancesContent()
    {
        SetupPlayerApplianceSlots();

        SetupShopApplianceSlot();
    }    

    #region ----- PLAYER SIDE [APPLIANCES] -----
    public void ApplianceSlotControl(FFM_ApplianceSlotUI.applianceType _type, bool _state)
    {
        switch (_type)
        {
            case FFM_ApplianceSlotUI.applianceType.BurgerPad:
                if(_state)
                {
                    BurgerPadSlot.gameObject.SetActive(true);
                    BurgerPadSlotEmpty.gameObject.SetActive(false);
                }
                else
                {
                    BurgerPadSlot.gameObject.SetActive(false);
                    BurgerPadSlotEmpty.gameObject.SetActive(true);
                }
                break;
            case FFM_ApplianceSlotUI.applianceType.CookerPad:
                if (_state)
                {
                    CookerPadSlot.gameObject.SetActive(true);
                    CookerPadSlotEmpty.gameObject.SetActive(false);
                }
                else
                {
                    CookerPadSlot.gameObject.SetActive(false);
                    CookerPadSlotEmpty.gameObject.SetActive(true);
                }
                break;
            case FFM_ApplianceSlotUI.applianceType.DrinkMachine:
                if (_state)
                {
                    DrinkMachineSlot.gameObject.SetActive(true);
                    DrinkMachineSlotEmpty.gameObject.SetActive(false);
                }
                else
                {
                    DrinkMachineSlot.gameObject.SetActive(false);
                    DrinkMachineSlotEmpty.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    public void SetupPlayerApplianceSlots()
    {
        BurgerPadSlot.DetectApplianceSlot();
        CookerPadSlot.DetectApplianceSlot();
        DrinkMachineSlot.DetectApplianceSlot();
    }

    public void RefreshPlayerCoinsLabel()
    {
        playerCoinsValueText.text = ProfileController.Instance.playerProfile.PlayerMoney.ToString();
    }

    #endregion

    #region ----- SHOP SIDE [APPLIANCES] -----

    void SetupShopApplianceSlot()
    {
        for (int i = 0; i < ItemDatabase.Instance.Appliances.Count; i++)
        {
            GameObject shopSlot = Instantiate(ApplianceSlotShop);
            shopSlot.transform.SetParent(ContentWrapper, false);
            shopSlot.transform.localScale = Vector2.one;
            shopSlot.GetComponent<FFM_ApplianceSlotUI>().SetupApplianceSlotUI(ItemDatabase.Instance.Appliances[i]);
        }
    }

    #endregion
    #endregion

}
