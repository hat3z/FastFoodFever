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
    string myApplianceHash;
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
                ProfileController.Instance.SetApplianceToSlot(DynamicTileID, ShopUIController.Instance.placingApplHash);
                ShopUIController.Instance.isPlacing = false;
                ShopUIController.Instance.placingApplHash = string.Empty;
                SetupSlotPrefab(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
                ShopUIController.Instance.GetAppliancesFromProfile(false);
                ShopUIController.Instance.PlaceMaskBehaviour(false);
                BuildUIController.Instance.SetFoodItemCount(ItemUIRow.itemType.Appliance);
                GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID).RemovePlacingObject();
                GamePlayController.Instance.CheckPlayerStartGame();
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
            if(ProfileController.Instance.playerProfile.PlayerAppliances.Count !=0)
            {
                gameObject.GetComponent<Image>().color = PlacedBackgroundColor;
                PlaceLabel.color = PlacedLabelColor;
                PlaceLabel.text = "Placed!";
                ApplImage.sprite = ItemDatabase.Instance.GetSpriteFromPath(ProfileController.Instance.GetApplianceFromProfileByHash(_dynamicTile.myApplianceHash).applianceImagePath);
                ApplNameLabel.text = ProfileController.Instance.GetApplianceFromProfileByHash(_dynamicTile.myApplianceHash).applianceName;
                _dynamicTile.SetupNamesByType(_dynamicTile.myAppliance);
                myApplianceID = _dynamicTile.myAppliance;
                myApplianceHash = _dynamicTile.myApplianceHash;
                DynamicTileID = _dynamicTile.ID;
                _dynamicTile.PlaceAppliancePrefab(ProfileController.Instance.GetApplianceFromProfileByHash(_dynamicTile.myApplianceHash).modelPath, false);
            }
        }
        SlotTypeLabel.text = "Slot" + _dynamicTile.ID;
    }

    void ShowPlacingHelper(DynamicTile _dynamicTile)
    {
        if(_dynamicTile.myAppliance == string.Empty)
        {
            _dynamicTile.PlaceAppliancePrefab(ProfileController.Instance.GetApplianceFromProfileByHash(ShopUIController.Instance.placingApplHash).modelPath, true);
        }

    }

    public void OnPointerEnter(PointerEventData e)
    {
        if(ShopUIController.Instance.isPlacing)
        {
            Debug.Log("myID: " + GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
            ShowPlacingHelper(GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID));
        }

    }

    public void OnPointerExit(PointerEventData e)
    {
        if (ShopUIController.Instance.isPlacing)
        {
            GamePlayController.Instance.GetDynamicTIleByID(DynamicTileID).RemovePlacingObject();
        }

    }

}
