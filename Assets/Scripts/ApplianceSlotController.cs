using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ApplianceSlotController : MonoBehaviour, IPointerClickHandler
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
        if(ShopUIController.Instance.isPlacing)
        {
            ProfileController.Instance.SetApplianceToSlot(DynamicTileID);
            ShopUIController.Instance.isPlacing = false;
            ShopUIController.Instance.placingApplID = string.Empty;
            SetupSlotPrefab(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
            ShopUIController.Instance.GetAppliancesFromProfile(true);
            ShopUIController.Instance.PlaceMaskBehaviour(false);
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
            }


        }
    }

}
