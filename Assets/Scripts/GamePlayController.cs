using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController Instance;

    public List<DynamicTile> DynamicTiles;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllDynamicTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Dynamic Tile handling section

    void GetAllDynamicTiles()
    {
        GameObject []temp = GameObject.FindGameObjectsWithTag("DynamicTile");
        for (int i = 0; i < temp.Length; i++)
        {
            DynamicTiles.Add(temp[i].GetComponent<DynamicTile>());
        }
    }

    #endregion

}
