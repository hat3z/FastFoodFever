using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("BUILD PANEL")]
    public Animator BuildPanelAnimator;
    [Header("-Appliances Section")]
    public List<ApplianceUIRow> ApplianceUIRows;

    [Header("Bottom Buttons")]
    public Button BuildModeButton;

    [Header("New Item Control")]
    public GameObject NewItemPanel;
    public Transform NewItemContent;

    // Appliances
    public GameObject NewAppliancePrefab;
    public List<NewApplianceUIRow> NewApplianceUIRows;

    // Food

    // Drink

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

    public void OpenBuildButtonEvent(bool _state)
    {
        BuildPanelAnimator.SetBool("isOpen", _state);
        if(_state)
        {
            BuildModeButton.interactable = false;
        }
        else
        {
            BuildModeButton.interactable = true;
        }
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

    #endregion

    #region New Item Handlings

    public void CloseNewItemPanel()
    {
        NewItemPanel.gameObject.SetActive(false);
    }

    // APPLIANCES

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

    void ClearNewApplianceList()
    {
        for (int i = 0; i < NewApplianceUIRows.Count; i++)
        {
            Destroy(NewApplianceUIRows[i].gameObject);
        }
        NewApplianceUIRows.Clear();
    }

    void SetupNewApplianceContent()
    {
        ClearNewApplianceList();
        for (int i = 0; i < ItemDatabase.Instance.Appliances.Count; i++)
        {
            GameObject newRow = Instantiate(NewAppliancePrefab);
            newRow.transform.SetParent(NewItemContent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            newRow.GetComponent<NewApplianceUIRow>().SetupAppliance(ItemDatabase.Instance.Appliances[i]);
            NewApplianceUIRows.Add(newRow.GetComponent<NewApplianceUIRow>());
        }

        
    }

    #endregion

}
