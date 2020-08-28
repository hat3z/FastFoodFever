#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CustomEditor(typeof(ItemDatabase))]
public class ItemDatabaseEditor : Editor
{
    private ItemDatabase itemDatabaseList;

    bool showFoodItems = false;
    private SerializedProperty foodItems;

    bool showIngrediens = false;
    private SerializedProperty ingredients;

    bool showAppliances = false;
    private SerializedProperty appliances;
    private SerializedProperty applianceModelPath;

    Color original = new Color();
    Color green = new Color();
    Color red = new Color();
    public void OnEnable()
    {
        itemDatabaseList = target as ItemDatabase;
        foodItems = serializedObject.FindProperty("FoodDatabase");
        ingredients = serializedObject.FindProperty("FoodIngredients");
        appliances = serializedObject.FindProperty("Appliances");
        green = Color.green;
        red = Color.red;
        original = GUI.color;
    }

    public override void OnInspectorGUI()
    {
        EditorUtility.SetDirty(itemDatabaseList);
        serializedObject.Update();


        #region Foods property
        GUI.backgroundColor = green;
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        GUI.backgroundColor = original;
        showFoodItems = EditorGUILayout.BeginToggleGroup("Show Food Items", showFoodItems);
        if(showFoodItems)
        {

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Food Items", EditorStyles.boldLabel);
            for (int i = 0; i < foodItems.arraySize; i++)
            {
                GUILayout.BeginVertical(EditorStyles.helpBox);

                SerializedProperty item = foodItems.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(item, true);

                if(itemDatabaseList.FoodDatabase[i].foodModelPath == string.Empty && Selection.activeGameObject != null)
                {
                    if (GUILayout.Button("Set Model Path!"))
                    {
                        itemDatabaseList.FoodDatabase[i].foodModelPath = Selection.activeGameObject.name;
                    }
                }


                GUI.backgroundColor = red;
                if (GUILayout.Button("Delete"))
                {
                    ShowDialogPromptFoodItem(i);
                }
                GUI.backgroundColor = original;
                GUILayout.EndVertical();
                EditorGUILayout.Space();

            }

            GUI.backgroundColor = green;
            if (GUILayout.Button("Add new FoodItem"))
            {
                itemDatabaseList.SetupNewFoodItem();
            }
            GUI.backgroundColor = original;

            EditorGUILayout.Separator();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndToggleGroup();
        GUI.backgroundColor = original;
        EditorGUILayout.EndVertical();
        #endregion

        #region Ingredients property
        GUI.backgroundColor = green;
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        GUI.backgroundColor = original;
        showIngrediens = EditorGUILayout.BeginToggleGroup("Show Food Ingredients", showIngrediens);

        if(showIngrediens)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Food Ingredients", EditorStyles.boldLabel);
            for (int i = 0; i < ingredients.arraySize; i++)
            {
                GUILayout.BeginVertical(EditorStyles.helpBox);

                SerializedProperty item = ingredients.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(item, true);

                GUI.backgroundColor = red;
                if (GUILayout.Button("Delete"))
                {
                    ShowDialogPromptFoodIngredients(i);
                }
                GUI.backgroundColor = original;

                GUILayout.EndVertical();
                EditorGUILayout.Space();

            }

            GUI.backgroundColor = green;
            if (GUILayout.Button("Add new FoodIngredient"))
            {
                itemDatabaseList.SetupNewFoodIngredientItem();
            }
            GUI.backgroundColor = original;
            EditorGUILayout.Separator();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndVertical();
        #endregion

        #region Appliances property
        GUI.backgroundColor = green;
        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        GUI.backgroundColor = original;
        showAppliances = EditorGUILayout.BeginToggleGroup("Show Appliances", showAppliances);

        if (showAppliances)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Appliances", EditorStyles.boldLabel);
            for (int i = 0; i < appliances.arraySize; i++)
            {
                GUILayout.BeginVertical(EditorStyles.helpBox);

                SerializedProperty item = appliances.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(item, true);

                //SerializedProperty modelPathItem = item.FindPropertyRelative("modelPath");
                //EditorGUILayout.PropertyField(modelPathItem, true);

                if(itemDatabaseList.Appliances[i].modelPath == string.Empty)
                {
                    if (GUILayout.Button("Set Model Path!"))
                    {
                        itemDatabaseList.Appliances[i].modelPath = Selection.activeGameObject.name;
                    }
                }


                GUI.backgroundColor = red;
                if (GUILayout.Button("Delete"))
                {
                    ShowDialogPromptAppliances(i);
                }
                GUI.backgroundColor = original;

                GUILayout.EndVertical();
                EditorGUILayout.Space();

            }

            GUI.backgroundColor = green;
            if (GUILayout.Button("Add new Appliance"))
            {
                itemDatabaseList.SetupNewApplianceItem();
            }
            GUI.backgroundColor = original;
            EditorGUILayout.Separator();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndVertical();
        #endregion

        serializedObject.ApplyModifiedProperties();
        
    }

    

    void SetModelPath(string _pathToset)
    {
        _pathToset = AssetDatabase.GetAssetPath(Selection.activeObject);
    }

    public void ShowDialogPromptFoodItem(int _itemIndex)
    {
        bool option = EditorUtility.DisplayDialog("Are you sure?", "This will delete the selected item from FoodItems", "Ok", "Cancel");
        if (option)
        {
            itemDatabaseList.FoodDatabase.RemoveAt(_itemIndex);
            EditorUtility.SetDirty(itemDatabaseList);
        }
    }

    public void ShowDialogPromptFoodIngredients(int _itemIndex)
    {
        bool option = EditorUtility.DisplayDialog("Are you sure?", "This will delete the selected item from FoodIngredients", "Ok", "Cancel");
        if (option)
        {
            itemDatabaseList.FoodIngredients.RemoveAt(_itemIndex);
            EditorUtility.SetDirty(itemDatabaseList);
        }
    }
    public void ShowDialogPromptAppliances(int _itemIndex)
    {
        bool option = EditorUtility.DisplayDialog("Are you sure?", "This will delete the selected item from FoodIngredients", "Ok", "Cancel");
        if (option)
        {
            itemDatabaseList.Appliances.RemoveAt(_itemIndex);
            EditorUtility.SetDirty(itemDatabaseList);
        }
    }



}
