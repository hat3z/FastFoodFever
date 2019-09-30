using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngredientsPanelController : MonoBehaviour
{
    public GameplayUIButton MyGameplayButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClosePanel()
    {
        MyGameplayButton.SetBaseColorToButton();
        gameObject.SetActive(false);
    }
}
