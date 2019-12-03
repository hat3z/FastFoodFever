using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderNPC : MonoBehaviour
{

    public Animator NPCAnimator;

    public int myOrderID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimByTrigger(string _trigger)
    {
        switch (_trigger)
        {
            case "comeToOrder":
                NPCAnimator.SetTrigger("comeToOrder");
                //WAITING TO ACTIVE!
                break;
            case "comeToOrderPoint":
                NPCAnimator.SetTrigger("comeToOrderPoint");
                StartCoroutine(GamePlayController.Instance.EnableNewOrderPanel(myOrderID));
                //ORDERING!
                break;
            case "comeToWait":
                NPCAnimator.SetTrigger("comeToWait");

                break;
            default:
                break;
        }

    }

    public void SetMyStartPosition(int _myID)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (_myID * 1));
    }

}
