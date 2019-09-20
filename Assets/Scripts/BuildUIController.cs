using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuildUIController : MonoBehaviour
{
    public static BuildUIController Instance;

    [Header("BUILD PANEL")]
    public Animator BuildPanelAnimator;
    public TextMeshProUGUI PlayerCoinsLabel;

    [Header("-Appliances Section")]
    public GameObject ApplianceUIRowPrefab;
    public Transform ApplianceParent;
    public List<ItemUIRow> ApplianceUIRows;

    [Header("-Food Section")]
    public GameObject FoodUIRowPrefab;
    public Transform FoodParent;
    public List<ItemUIRow> FoodUIRows;

    [Header("-Ingredients Section")]
    public GameObject IngredientsUIRowPrefab;
    public Transform IngredientParent;
    public List<ItemUIRow> IngredientUIRows;

    [Header("-Drink Section")]
    public GameObject DrinkUIRowPrefab;
    public Transform DrinkParent;
    public List<ItemUIRow> DrinkUIRows;

    [Header("Bottom Buttons")]
    public Button BuildModeButton;

    [Header("New Item Control")]
    public GameObject NewItemPanel;
    public Transform NewItemContent;


    [Header("-New Appliance--")]
    public GameObject NewApplianceUIRowPrefab;
    public List<NewItemUIRow> NewApplianceUIRows;

    [Header("-New Food--")]
    public GameObject NewFoodUIRowPrefab;
    public List<NewItemUIRow> NewFoodUIRows;

    [Header("-New Ingredients--")]
    public GameObject NewIngredientUIRowPrefab;
    public List<NewItemUIRow> NewIngredientsUIRows;

    [Header("-New Drink--")]
    public GameObject NewDrinkUIRowPrefab;
    public List<NewItemUIRow> NewDrinkUIRows;


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

    void GetPlayerCoinsFromProfile()
    {
        PlayerCoinsLabel.text = ProfileController.Instance.PlayerMoney.ToString();
    }

    public void OpenBuildButtonEvent(bool _state)
    {
        BuildPanelAnimator.SetBool("isOpen", _state);
        if(_state)
        {
            BuildModeButton.interactable = false;
            GetAppliancesFromProfile(false);
            GetPlayerCoinsFromProfile();
        }
        else
        {
            BuildModeButton.interactable = true;
        }
    }

    /// <summary>
    /// Refreshing all the contents.
    /// </summary>
    public void RefreshingBuildUIContent()
    {
        GetAppliancesFromProfile(true);
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

    public IEnumerator RefreshPanelWithDelay(GameObject _panel)
    {
        _panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(.05f);
        _panel.gameObject.SetActive(true);
    }

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

    void ClearItemList(List<ItemUIRow> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            Destroy(_list[i].gameObject);
        }
        _list.Clear();
    }

    #endregion

    #region New Item Handlings

    public void CloseNewItemPanel()
    {
        NewItemPanel.gameObject.SetActive(false);
        ClearNewItemList(NewApplianceUIRows);
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
                default:
                    break;
            }

        }

    }

    // Appliances
    void ClearNewItemList(List<NewItemUIRow> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            Destroy(_list[i].gameObject);
        }
        _list.Clear();
    }

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

    #endregion

}
