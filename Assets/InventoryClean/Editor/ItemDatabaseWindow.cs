using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ItemDatabaseWindow : EditorWindow
{
    Vector2 scrollPos;
    private Editor editor;

    public ItemDatabase _itemDatabase;

    [MenuItem("htz/Food Database")]

    public static void ShowObjectWindow()
    {
        var window = EditorWindow.GetWindow<ItemDatabaseWindow>(true, "Food Database Editor", true);
        window.editor = Editor.CreateEditor(ItemDatabase.Instance);   
    }

    private void OnGUI()
    {
        _itemDatabase = ItemDatabase.Instance;

        EditorGUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(500), GUILayout.Height(position.height));

       this.editor.OnInspectorGUI();

        EditorGUILayout.Space();

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
    }
}
