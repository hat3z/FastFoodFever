using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFM_PlayerUIController : MonoBehaviour
{
    public static FFM_PlayerUIController Instance;
    GameObject Player;
    PlayerLook playerLook;


    [Header("Canvases")]
    public Canvas PlayerCanvas;
    public Canvas RestaurantCanvas;

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
        SetupApplianceSlots();
    }

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

    void SetupApplianceSlots()
    {
        BurgerPadSlot.DetectApplianceSlot();
        CookerPadSlot.DetectApplianceSlot();
        DrinkMachineSlot.DetectApplianceSlot();
    }

}
