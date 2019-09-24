using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ApplianceSlotController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Color EmptyBackgroundColor;
    public Color PlacedBackgroundColor;
    public Color NotPlacedLabelColor;
    public Color PlacedLabelColor;

    public Image ApplImage;
    public TextMeshProUGUI ApplNameLabel;
    public TextMeshProUGUI SlotTypeLabel;
    public TextMeshProUGUI PlaceLabel;

    public int DynamicTileID;
    string myApplianceID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData e)
    {
        if(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID).myAppliance == string.Empty)
        {
            if (ShopUIController.Instance.isPlacing)
            {
                ProfileController.Instance.SetApplianceToSlot(DynamicTileID);
                ShopUIController.Instance.isPlacing = false;
                ShopUIController.Instance.placingApplID = string.Empty;
                SetupSlotPrefab(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
                ShopUIController.Instance.GetAppliancesFromProfile(false);
                ShopUIController.Instance.PlaceMaskBehaviour(false);
                BuildUIController.Instance.SetAppliancesSlotCount();
                GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID).RemoveObjectModel();
            }
        }

    }


    public void SetupSlotPrefab(DynamicTile _dynamicTile)
    {
        if(_dynamicTile.myAppliance == string.Empty)
        {
            gameObject.GetComponent<Image>().color = EmptyBackgroundColor;
            PlaceLabel.color = NotPlacedLabelColor;
            PlaceLabel.text = "Not Placed!";
            ApplNameLabel.text = "Empty Appliance";
            DynamicTileID = _dynamicTile.ID;
        }
        else
        {
            if(ProfileController.Instance.PlayerAppliances.Count !=0)
            {
                gameObject.GetComponent<Image>().color = PlacedBackgroundColor;
                PlaceLabel.color = PlacedLabelColor;
                PlaceLabel.text = "Placed!";
                ApplImage.sprite = ProfileController.Instance.GetApplianceFromProfileByID(_dynamicTile.myAppliance).applianceImage;
                ApplNameLabel.text = ProfileController.Instance.GetApplianceFromProfileByID(_dynamicTile.myAppliance).applianceName;
                _dynamicTile.SetupNamesByType(_dynamicTile.myAppliance);
                myApplianceID = _dynamicTile.myAppliance;
                _dynamicTile.PlaceAppliancePrefab(ProfileController.Instance.GetApplianceFromProfileByID(_dynamicTile.myAppliance).model, false);
            }
        }
        SlotTypeLabel.text = "Slot" + _dynamicTile.ID;
    }

    void ShowPlacingHelper(DynamicTile _dynamicTile)
    {
        if(_dynamicTile.myAppliance == string.Empty)
        {
            _dynamicTile.PlaceAppliancePrefab(ItemDatabase.Instance.GetApplianceByID(ShopUIController.Instance.placingApplID).model, true);
        }

    }

    public void OnPointerEnter(PointerEventData e)
    {
        if(ShopUIController.Instance.isPlacing)
        {
            ShowPlacingHelper(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
        }

    }

    public void OnPointerExit(PointerEventData e)
    {
        if(ShopUIController.Instance.isPlacing)
        {
            GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID).RemoveObjectModel();
        }

    }

}
