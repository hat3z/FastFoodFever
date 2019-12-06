using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNPCController : MonoBehaviour
{

    public static OrderNPCController Instance;
    public GameObject OrderNPCPrefab;
    public Transform NPCSpawnPoint;
    public List<OrderNPC> orderNPCs;

    public List<OrderNPC> activeNPCs;

    public List<OrderNPC> waitingNPCs;

    public List<WaitingSpot> WaitingSpots;

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

    public WaitingSpot GetFirstFreeWaitingSpot()
    {
        foreach (WaitingSpot item in WaitingSpots)
        {
            if(item.isFree)
            {
                return item;
            }
        }
        return null;
    }

    public void SetOrderNPCToWaitSpot()
    {

    }

    public void SetActiveOrderToWait()
    {
        waitingNPCs.Add(activeNPCs[0]);
        waitingNPCs[waitingNPCs.Count-1].GetComponent<OrderNPC>().PlayAnimByTrigger("comeToWait");
        GamePlayController.Instance.RefreshOrderDataByID(waitingNPCs[waitingNPCs.Count-1].myOrderID, Order.orderProgress.Waiting, true);
        activeNPCs.Clear();
        StartCoroutine(Refresh(GamePlayController.Instance.orderMoveTimeToActive, GamePlayController.Instance.orderMoveTimeInactive));
    }

    public IEnumerator Refresh(float waitTimeToMove, float waitTimeInactive)
    {
        if(orderNPCs.Count !=0)
        {
            yield return new WaitForSeconds(waitTimeToMove);
            activeNPCs.Add(orderNPCs[0]);
            orderNPCs.Remove(activeNPCs[0]);
            activeNPCs[0].GetComponent<OrderNPC>().PlayAnimByTrigger("comeToOrderPoint");
            for (int i = 0; i < orderNPCs.Count; i++)
            {
                yield return new WaitForSeconds(waitTimeInactive);
                orderNPCs[i].GetComponent<OrderNPC>().PlayAnimByTrigger("comeToOrder");
            }
        }

    }


    public void CreateNewOrderNPC(Order _orderData)
    {
        GameObject newOrderNPC = Instantiate(OrderNPCPrefab, NPCSpawnPoint);
        newOrderNPC.transform.localScale = Vector3.one;
        newOrderNPC.transform.SetParent(gameObject.transform);
        newOrderNPC.GetComponent<OrderNPC>().myOrderID = _orderData.OrderID;
        newOrderNPC.GetComponent<OrderNPC>().SetMyStartPosition(GamePlayController.Instance.Orders.Count);
        orderNPCs.Add(newOrderNPC.GetComponent<OrderNPC>());
    }

    public void ClearOrderNPCList()
    {
        if(orderNPCs.Count > 0)
        {
            for (int i = 0; i < orderNPCs.Count; i++)
            {
                Destroy(orderNPCs[i].gameObject);
            }
            orderNPCs.Clear();
        }
    }


}
[System.Serializable]
public class WaitingSpot
{
    public int spotID;
    public bool isFree = true;
}
