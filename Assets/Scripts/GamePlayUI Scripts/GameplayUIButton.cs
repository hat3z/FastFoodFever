using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayUIButton : MonoBehaviour
{
    public GameObject MyPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHoverToButton(Image _image)
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
    }

    public void SetBaseColorToButton(Image _image)
    {
        if (!MyPanel.gameObject.activeSelf)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
        }
    }

    public void SetBaseColorToButton()
    {
        Image myImage = GetComponent<Image>();
        myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, 0);
    }

    public void OpenPanel(string _panelName)
    {
        switch (_panelName)
        {
            case "orders":
                MyPanel.GetComponent<OrdersPanelController>().RefreshWaitingOrders();
                break;
            case "menus":
                break;
            case "ingredients":
                break;
            default:
                break;
        }
        if (!MyPanel.activeSelf)
        {
            MyPanel.gameObject.SetActive(true);
            SetHoverToButton(GetComponent<Image>());
        }

    }
}
