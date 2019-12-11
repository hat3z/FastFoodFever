using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplianceController : MonoBehaviour
{
    RaycastHit hit;

    string myApplianceHash;
    int myDynamicTileID;
    public GameObject MyPanelPrefab;
    public GameObject MyAppliancePanel;

    // Start is called before the first frame update
    void Start()
    {
    }

    public string GetMyApplianceHash()
    {
        return myApplianceHash;
    }

    public void SetMyData(string _aplHash, int _dID)
    {
        myApplianceHash = _aplHash;
        myDynamicTileID = _dID;
    }

    public bool IsPanelOpened()
    {
        if(HadAppliancePanel())
        {
            if (MyAppliancePanel.gameObject.activeSelf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool HadAppliancePanel()
    {
        if(MyAppliancePanel != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CreateAppliancePanel()
    {
        GameObject newPanel = Instantiate(MyPanelPrefab);
        MyAppliancePanel = newPanel;
        newPanel.transform.SetParent(GameUIController.Instance.PanelsParent);
        newPanel.transform.localScale = new Vector3(1, 1, 1);
        GamePlayController.Instance.GetDynamicTIleByID(myDynamicTileID).SetupAppliancePanelPosition(newPanel);
    }

   
}
