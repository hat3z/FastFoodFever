using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("BUILD PANEL")]
    public Animator BuildPanelAnimator;
    [Header("-Appliances Section")]


    [Header("Bottom Buttons")]
    public Button BuildModeButton;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region BuildPanel Handlings

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

    #endregion

}
