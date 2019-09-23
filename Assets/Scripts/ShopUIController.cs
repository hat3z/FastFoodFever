using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopUIController : MonoBehaviour
{
    public static ShopUIController Instance;

    [Header("SHOP PANEL")]
    public Animator BuildPanelAnimator;
    public Animator ShopPanelAnimator;
    public TextMeshProUGUI PlayerCoinsLabel;

    [Header("Placing")]
    public bool isPlacing = false;
    public string placingApplID;
    public GameObject PlacingMask;
    public Button CloseButtonBuild;
    public Button CloseButtonShop;

    [Header("-Appliances Section")]
    public GameObject ApplianceUIRowPrefab;
    public Transform ApplianceParent;
    public List<ItemUIRow> ApplianceUIRows;

    [Header("-Ingredients Section")]
    public GameObject IngredientsUIRowPrefab;
    public Transform IngredientParent;
    public List<ItemUIRow> IngredientUIRows;

    [Header("Bottom Buttons")]
    public Button BuildModeButton;

    [Header("New Item Control")]
    public GameObject NewItemPanel;
    public Transform NewItemContent;


    [Header("-New Appliance--")]
    public GameObject NewApplianceUIRowPrefab;
    public List<NewItemUIRow> NewApplianceUIRows;

    [Header("-New Ingredients--")]
    public GameObject NewIngredientUIRowPrefab;
    public List<NewItemUIRow> NewIngredientsUIRows;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TearDownPanels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region BuildPanel Handlings

    void TearDownPanels()
    {
        NewItemPanel.gameObject.SetActive(false);
    }

    public void GetPlayerCoinsFromProfile()
    {
        PlayerCoinsLabel.text = ProfileController.Instance.PlayerMoney.ToString();
    }

    public void OpenBuildButtonEvent(bool _state)
    {
        BuildPanelAnimator.SetBool("isOpen", _state);
        ShopPanelAnimator.SetBool("isOpen", _state);
        if(_state)
        {
            BuildModeButton.interactable = false;
            GetAppliancesFromProfile(false);
            GetIngredientsFromProfile(false);
            GetPlayerCoinsFromProfile();
            BuildUIController.Instance.SetupApplianceSlots();
        }
        else
        {
            BuildModeButton.interactable = true;
        }
    }

    /// <summary>
    /// Refreshing all the contents.
    /// </summary>
    public void RefreshingBuildUIContent(string _refreshContent)
    {
        switch (_refreshContent)
        {
            case "appliance":
                GetAppliancesFromProfile(true);
                break;
            case "ingredient":
                GetIngredientsFromProfile(true);
                break;
            default:
                break;
        }

        GetPlayerCoinsFromProfile();
    }

    //Item showing
    public void ShowItems(GameObject _panel)
    {
        bool _state = _panel.activeSelf;
        if(_state)
        {
            _panel.gameObject.SetActive(false);
        }
        else
        {
            _panel.gameObject.SetActive(true);
        }
    }

    void ClearItemList(List<ItemUIRow> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            Destroy(_list[i].gameObject);
        }
        _list.Clear();
    }

    public IEnumerator RefreshPanelWithDelay(GameObject _panel)
    {
        _panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(.05f);
        _panel.gameObject.SetActive(true);
    }

    // Appliance
    public void GetAppliancesFromProfile(bool useRefresh)
    {
        if(useRefresh)
        {
            StartCoroutine(RefreshPanelWithDelay(ApplianceParent.gameObject));
        }

        ClearItemList(ApplianceUIRows);
        for (int i = 0; i < ProfileController.Instance.PlayerAppliances.Count; i++)
        {
            GameObject newRow = Instantiate(ApplianceUIRowPrefab);
            newRow.transform.SetAsFirstSibling();
            newRow.transform.SetParent(ApplianceParent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            ApplianceUIRows.Add(newRow.GetComponent<ItemUIRow>());
            newRow.GetComponent<ItemUIRow>().SetupApplianceItemUI(ProfileController.Instance.PlayerAppliances[i]);
        }
    }

    //Ingredient
    void GetIngredientsFromProfile(bool useRefresh)
    {
        if (useRefresh)
        {
            StartCoroutine(RefreshPanelWithDelay(IngredientParent.gameObject));
        }

        ClearItemList(IngredientUIRows);
        for (int i = 0; i < ProfileController.Instance.PlayerFoodIngredients.Count; i++)
        {
            GameObject newRow = Instantiate(IngredientsUIRowPrefab);
            newRow.transform.SetAsFirstSibling();
            newRow.transform.SetParent(IngredientParent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            IngredientUIRows.Add(newRow.GetComponent<ItemUIRow>());
            newRow.GetComponent<ItemUIRow>().SetupIngredientItemUI(ProfileController.Instance.PlayerFoodIngredients[i]);
        }
    }



    #endregion

    #region New Item Handlings

    public void CloseNewItemPanel()
    {
        NewItemPanel.gameObject.SetActive(false);
        ClearNewItemList(NewApplianceUIRows);
        ClearNewItemList(NewIngredientsUIRows);
    }

    public void OpenNewItemPanel(string _itemType)
    {

        if(!NewItemPanel.gameObject.activeSelf)
        {
            switch (_itemType)
            {
                case "appliance":
                    SetupNewApplianceContent();
                    NewItemPanel.gameObject.SetActive(true);
                    break;
                case "ingredients":
                    SetupNewIngredientContent();
                    NewItemPanel.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }

        }

    }

    void ClearNewItemList(List<NewItemUIRow> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            Destroy(_list[i].gameObject);
        }
        _list.Clear();
    }

    // Appliances


    void SetupNewApplianceContent()
    {
        ClearNewItemList(NewApplianceUIRows);
        for (int i = 0; i < ItemDatabase.Instance.Appliances.Count; i++)
        {
            GameObject newRow = Instantiate(NewApplianceUIRowPrefab);
            newRow.transform.SetParent(NewItemContent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            newRow.GetComponent<NewItemUIRow>().SetupAppliance(ItemDatabase.Instance.Appliances[i]);
            NewApplianceUIRows.Add(newRow.GetComponent<NewItemUIRow>());
        }       
    }

    // Ingredients

    void SetupNewIngredientContent()
    {
        ClearNewItemList(NewIngredientsUIRows);
        for (int i = 0; i < ItemDatabase.Instance.FoodIngredients.Count; i++)
        {
            GameObject newRow = Instantiate(NewIngredientUIRowPrefab);
            newRow.transform.SetParent(NewItemContent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            newRow.GetComponent<NewItemUIRow>().SetupIngredient(ItemDatabase.Instance.FoodIngredients[i]);
            NewIngredientsUIRows.Add(newRow.GetComponent<NewItemUIRow>());
        }
    }

    #endregion

    #region Placing Handlings

    public void PlaceMaskBehaviour(bool _state)
    {
        PlacingMask.gameObject.SetActive(_state);
        CloseButtonBuild.interactable = !_state;
        CloseButtonShop.interactable = !_state;
    }

    #endregion


}
