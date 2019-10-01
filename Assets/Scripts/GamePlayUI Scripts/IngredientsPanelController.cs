using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngredientsPanelController : MonoBehaviour
{
    public static IngredientsPanelController Instance;

    public GameplayUIButton MyGameplayButton;

    public GameObject IngredientRowPrefab;

    public List<GameObject> IngredientRows;

    public Transform ContentParent;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        DrawIngredients();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawIngredients()
    {
        ClearList();
        for (int i = 0; i < ProfileController.Instance.playerProfile.PlayerFoodIngredients.Count; i++)
        {
            GameObject newRow = Instantiate(IngredientRowPrefab);
            newRow.transform.SetParent(ContentParent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            newRow.GetComponent<IngredientRowController>().SetupIngredientData(ProfileController.Instance.playerProfile.PlayerFoodIngredients[i].IngredientID);
            IngredientRows.Add(newRow);
        }
    }

    void ClearList()
    {
        for (int i = 0; i < IngredientRows.Count; i++)
        {
            Destroy(IngredientRows[i].gameObject);
        }
        IngredientRows.Clear();
    }

    public void ClosePanel()
    {
        MyGameplayButton.SetBaseColorToButton();
        gameObject.SetActive(false);
    }
}
