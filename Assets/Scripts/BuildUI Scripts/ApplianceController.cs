using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplianceController : MonoBehaviour
{
    RaycastHit hit;

    public Vector2 UIPanelPosition;

    // Start is called before the first frame update
    void Start()
    {
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
                    Debug.Log("yiss");
                }

            }
        }
    }
}
