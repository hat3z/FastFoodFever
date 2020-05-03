using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIController : MonoBehaviour
{

    public static GameUIController Instance;
    RaycastHit hit;
    public GameObject GameplayUI;

    public List<GameObject> DragabblePanels;

    [Header("Appliance Panels")]
    public Transform PanelsParent;
    public List<GameObject> ActiveAppliancePanels;


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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CameraController.Instance.MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Appliance")
                {
                    ApplianceController detectedAC = hit.transform.GetComponent<ApplianceController>();
                    if(!detectedAC.IsPanelOpened())
                    {
                        SetupBurgerPanel(detectedAC);
                    }

                }

            }
        }
    }

    public void SetupBurgerPanel(ApplianceController _applianceController)
    {
        if(_applianceController.HadAppliancePanel())
        {
            _applianceController.MyAppliancePanel.gameObject.SetActive(true);
            Debug.Log("ExistsDetectedACHash: " + _applianceController.GetMyApplianceHash());
        }
        else
        {
            ActiveAppliancePanels.Add(_applianceController.gameObject);
            _applianceController.CreateAppliancePanel();
            Debug.Log("DetectedACHash: " + _applianceController.GetMyApplianceHash());
        }
    }


    public IEnumerator EnableGameplayUIDelayed()
    {
        CameraController.Instance.FadeToPlayCamera = true;
        yield return new WaitForSeconds(1f);
        GameplayUI.gameObject.SetActive(true);
        GamePlayController.Instance.EnablePlayMode();
    }



}
