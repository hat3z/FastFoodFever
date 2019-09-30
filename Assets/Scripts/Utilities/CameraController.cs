using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public Camera MainCamera;

    public float BuildCameraZoom;
    public Color BuildCameraBGColor;
    public bool FadeToBuildCamera;

    public float PlayCameraZoom;
    public Color PlayCameraBGColor;
    public bool FadeToPlayCamera;

    public float transitionTime;
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
        if(FadeToBuildCamera)
        {
            SetZoom(BuildCameraZoom, true);
        }
        if(FadeToPlayCamera)
        {
            SetZoom(PlayCameraZoom, false);
        }
    }

    void SetZoom(float _amount, bool _cam)
    {
        if(MainCamera.orthographicSize != _amount)
        {
            MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, _amount, transitionTime * Time.deltaTime);
            StartCoroutine(TurnOffTransition(_cam));
        }
    }
    IEnumerator TurnOffTransition(bool _isBuildCam)
    {
        yield return new WaitForSeconds(transitionTime);
        if(_isBuildCam)
        {
            FadeToBuildCamera = false;
        }
        else
        {
            FadeToPlayCamera = false;
        }
    }


}
