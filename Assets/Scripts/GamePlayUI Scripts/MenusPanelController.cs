using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenusPanelController : MonoBehaviour
{
    public GameplayUIButton MyGameplayButton;

    public List<GameObject> FoodItems;

    public GameObject FoodItemPrefab;
    public Transform ContentParent;

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearList();
        for (int i = 0; i < ProfileController.Instance.playerProfile.PlayerFoodItems.Count; i++)
        {
            GameObject newRow = Instantiate(FoodItemPrefab);
            newRow.transform.SetParent(ContentParent);
            newRow.transform.localScale = new Vector3(1, 1, 1);
            newRow.GetComponent<MenuItemController>().SetupFoodItemData(ItemDatabase.Instance.GetFoodItemByID(ProfileController.Instance.playerProfile.PlayerFoodItems[i].foodID).foodID);
            FoodItems.Add(newRow);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    void ClearList()
    {
        for (int i = 0; i < FoodItems.Count; i++)
        {
            Destroy(FoodItems[i].gameObject);
        }

        FoodItems.Clear();
    }

    public void ClosePanel()
    {
        MyGameplayButton.SetBaseColorToButton();
        gameObject.SetActive(false);
    }
}
