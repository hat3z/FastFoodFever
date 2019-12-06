using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIController : MonoBehaviour
{

    public static GameUIController Instance;

    public GameObject GameplayUI;

    public List<GameObject> DragabblePanels;

    [Header("Appliance Panels")]
    public Transform PanelsParent;
    public List<BurgerPadController> BP_Panels;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameplayUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SetupBurgerPanel(ApplianceController _applianceController, BurgerPadController _BPController)
    {
        if(!IsBurgerPadPanelExists(_applianceController.GetMyApplianceHash()))
        {
            BP_Panels.Add(_BPController);
            _applianceController.CreateAppliancePanel();
        }
        else
        {
            _applianceController.MyAppliancePanel.gameObject.SetActive(true);
        }
    }

    bool IsBurgerPadPanelExists(string _applianceID)
    {
        Debug.Log(_applianceID);
        for (int i = 0; i < BP_Panels.Count; i++)
        {
            if(BP_Panels[i].myApplianceID == _applianceID)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public IEnumerator EnableGameplayUIDelayed()
    {
        CameraController.Instance.FadeToPlayCamera = true;
        yield return new WaitForSeconds(1f);
        GameplayUI.gameObject.SetActive(true);
        GamePlayController.Instance.EnablePlayMode();
    }



}
