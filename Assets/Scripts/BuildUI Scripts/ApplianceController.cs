using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplianceController : MonoBehaviour
{
    RaycastHit hit;

    public Vector2 UIPanelPosition;

    string myApplianceHash;

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

    public void SetMyApplianceID(string _aplHash)
    {
        myApplianceHash = _aplHash;
    }

    public void CreateAppliancePanel()
    {
        GameObject newPanel = Instantiate(MyPanelPrefab);
        newPanel.transform.SetParent(GameUIController.Instance.PanelsParent);
        newPanel.transform.localScale = new Vector3(1, 1, 1);
        newPanel.gameObject.GetComponent<BurgerPadController>().myApplianceID = myApplianceHash;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CameraController.Instance.MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Appliance")
                {
                    GameUIController.Instance.SetupBurgerPanel(this, MyPanelPrefab.GetComponent<BurgerPadController>());
                }

            }
        }
    }
}
