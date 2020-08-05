using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFM_PlayerUIController : MonoBehaviour
{
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
        
    }

    public void SetupPlayerApplianceSlots()
    {

    }

}
