using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController Instance;

    public List<DynamicTile> DynamicTiles;
    public Material PlacingMaterial;
    public GameObject activePlacingApplliance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ProfileController.Instance.LoadProfileFromFile();
        ShopUIController.Instance.GetAppliancesFromProfile(false);
        BuildUIController.Instance.SetupApplianceSlots();
        BuildUIController.Instance.SetupFoodItemSlotFromList(ProfileController.Instance.playerProfile.PlayerFoodItems, false);
        BuildUIController.Instance.SetFoodItemCount(ItemUIRow.itemType.Food);
        BuildUIController.Instance.SetFoodItemCount(ItemUIRow.itemType.Drink);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Dynamic Tile handling section

    IEnumerator SetApplianceToDynamicTile()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < DynamicTiles.Count; i++)
        {
            DynamicTiles[i].GetComponent<DynamicTile>().SetApplianceData(DynamicTiles[i]);
        }
    }

    public DynamicTile GetDynamicTIleByID(int _id)
    {
        for (int i = 0; i < DynamicTiles.Count; i++)
        {
            if(DynamicTiles[i].ID == _id)
            {
                return DynamicTiles[i];
            }
        }
        return null;
    }

    public void ClearActivePlacingAppliance()
    {
        if(activePlacingApplliance != null)
        {
            activePlacingApplliance = null;
        }

    }

    public void SetActivePlacingAppliance(GameObject _model)
    {
        if(activePlacingApplliance == null)
        {
            activePlacingApplliance = _model;
        }
    }

    #endregion

}
