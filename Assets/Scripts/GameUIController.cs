using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIController : MonoBehaviour
{

    public static GameUIController Instance;

    public GameObject GameplayUI;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameplayUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonText()
    {

    }

    public IEnumerator EnableGameplayUIDelayed()
    {
        CameraController.Instance.FadeToPlayCamera = true;
        yield return new WaitForSeconds(1f);
        GameplayUI.gameObject.SetActive(true);
    }

}
