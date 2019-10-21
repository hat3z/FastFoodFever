using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNPCController : MonoBehaviour
{

    public static OrderNPCController Instance;
    public GameObject OrderNPCPrefab;
    public Transform NPCSpawnPoint;
    public float nextOrderTime;
    public List<OrderNPC> orderNPCs;
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

    public void SpawnOrderNPC()
    {
        for (int i = 0; i < GamePlayController.Instance.Orders.Count; i++)
        {
            GameObject newOrderNPC = Instantiate(OrderNPCPrefab, NPCSpawnPoint);
            newOrderNPC.transform.localScale = Vector3.one;
            newOrderNPC.transform.SetParent(gameObject.transform);
            newOrderNPC.GetComponent<OrderNPC>().myOrderID = GamePlayController.Instance.Orders[i].OrderID;
            orderNPCs.Add(newOrderNPC.GetComponent<OrderNPC>());
        }
    }


}
