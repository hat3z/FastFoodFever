using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDragger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    GameObject MainParentGO;
    public GameObject MyPanel;
    GameObject MyHeader;
    int maxOrder;

    bool canDrag;
    Vector3 mouseStartPos;
    Vector3 objectPos;
    private void Awake()
    {
        MainParentGO= transform.parent.transform.parent.gameObject;
        maxOrder = MainParentGO.transform.childCount - 1;
        MyHeader = gameObject;
    }

    void Update()
    {
        if(canDrag)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 move = mousePos - mouseStartPos;
            MyPanel.transform.position = objectPos + move;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        canDrag = true;
        MyPanel.transform.SetSiblingIndex(maxOrder);
        mouseStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        objectPos = MyPanel.transform.position;

    }

    public void OnPointerUp(PointerEventData e)
    {
        canDrag = false;
    }

}
